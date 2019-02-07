using System;
using System.ComponentModel.DataAnnotations;

namespace Blog.ValidationAttributes
{
    public class RequiredIfAttribute : ValidationAttribute
    {
        private RequiredAttribute _innerAttribute = new RequiredAttribute();

        public string DependentProperty { get; set; }
        public object TargetValue { get; set; }

        public RequiredIfAttribute(string dependentProperty, object targetValue)
             : this(dependentProperty, targetValue, null)
        {
        }

        public RequiredIfAttribute(string dependentProperty, object targetValue, string errorMessage)
            : base(errorMessage)
        {
            DependentProperty = dependentProperty;
            TargetValue = targetValue;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (ShouldRunValidation(value, DependentProperty, TargetValue, validationContext))
            {
                if (!_innerAttribute.IsValid(value))
                {
                    return new ValidationResult(FormatErrorMessage(validationContext.DisplayName), new[] { validationContext.MemberName });
                }
            }

            return ValidationResult.Success;
        }

        protected bool ShouldRunValidation(object value, string dependentProperty, object targetValue, ValidationContext validationContext)
        {
            var dependentvalue = GetDependentFieldValue(dependentProperty, validationContext);

            return (dependentvalue == null && targetValue == null) || (dependentvalue != null && !dependentvalue.Equals(targetValue));
        }

        protected object GetDependentFieldValue(string dependentProperty, ValidationContext validationContext)
        {
            var containerType = validationContext.ObjectInstance.GetType();
            var field = containerType.GetProperty(dependentProperty);

            if (field == null)
            {
                throw new ArgumentException(containerType.Name, dependentProperty);
            }

            var dependentvalue = field.GetValue(validationContext.ObjectInstance, null);
            return dependentvalue;
        }
    }
}
