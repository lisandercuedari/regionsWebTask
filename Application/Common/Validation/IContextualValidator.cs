using System.Threading;
using System.Threading.Tasks;

namespace Application.Common.Validation
{ 
    public interface IContextualValidator<in T>
    {
        public Task<ValidationResult> Validate(T value, CancellationToken cancellationToken = new CancellationToken());
    }
}