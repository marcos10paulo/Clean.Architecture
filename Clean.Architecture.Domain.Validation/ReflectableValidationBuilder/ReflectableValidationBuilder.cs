using Clean.Architecture.Domain.Validation.ErrorBase;
using Clean.Architecture.Domain.Validation.ValidationBase;

namespace Clean.Architecture.Domain.Validation.ReflectableValidationBuilder
{
    public class ReflectableValidationBuilder
    {
        private readonly Dictionary<Error, IReflectableValidationRule> _validations;

        public ReflectableValidationBuilder(Dictionary<Error, IReflectableValidationRule> validations)
        {
            _validations = validations;
        }

        public ReflectableValidationBuilder AddValidation(IReflectableValidationRule validationRule)
        {

            if (!_validations.ContainsKey(validationRule.Error) && validationRule is not null)
            {
                _validations.Add(validationRule.Error, validationRule);
            }

            return this;
        }

        public ReflectableValidationBuilder RemoveValidation(Error error)
        {
            if (_validations.ContainsKey(error))
            {
                _validations.Remove(error);
            }
            return this;
        }

        public ReflectableValidationBuilder AddValidationsBatch(List<IReflectableValidationRule> validations)
        {
            foreach (IReflectableValidationRule validation in validations)
            {
                AddValidation(validation);
            }

            return this;
        }

        public ReflectableValidationBuilder RemoveValidationsBatch(List<IReflectableValidationRule> validations)
        {
            foreach (IReflectableValidationRule validation in validations)
            {
                RemoveValidation(validation.Error);
            }

            return this;
        }

        public ReflectableValidationBuilder RemoveValidationsBatch(List<Error> errors)
        {
            foreach (var error in errors)
            {
                RemoveValidation(error);
            }

            return this;
        }

        public Result<T> Validate<T>(T entity, Error error)
        {
            if (_validations.ContainsKey(error))
            {
                return _validations[error].Validate(entity);
            }

            return Result<T>.Fail(Error.Unexpected(description: $"Could not find validation with error {error} inside this builder!"));
        }

        public Result<T> ValidateBatch<T>(T entity)
        {

            foreach (KeyValuePair<Error, IReflectableValidationRule> entry in _validations)
            {
                var result = entry.Value.Validate(entity);
                if (result.IsFailure)
                {
                    return result;
                }
            }

            return Result<T>.Ok(entity);
        }

        public ReflectableValidationBuilder Merge(ReflectableValidationBuilder merginBuilder)
        {
            merginBuilder._validations.Values.ToList().ForEach(validation => this.AddValidation(validation));
            return this;
        }

        public IReflectableValidationRule GetValidationRule(Error error)
        {
            if (!_validations.ContainsKey(error))
                return _validations[error];

            return null;
        }
    }
}
