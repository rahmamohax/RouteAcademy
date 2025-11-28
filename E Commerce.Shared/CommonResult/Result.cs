

namespace E_Commerce.Shared.CommonResult
{
    public class Result
    {
        private readonly List<Error> _errors = [];
        public bool IsSuccess => _errors.Count == 0;
        public IReadOnlyList<Error> Errors => _errors;

        //OK result
        protected Result()
        {
            
        }

        protected Result(Error error)
        {
            _errors.Add(error);
        }

        protected Result(List<Error> errors)
        {
            _errors.AddRange(errors);
        }

        public static Result Ok() => new Result();
        public static Result Fail(Error error) => new Result(error);
        public static Result Fail(List<Error> errors) => new Result(errors);

    }

    public class Result<T> : Result
    {
        private readonly T _value;
        public T Value => IsSuccess? _value: throw new InvalidOperationException("Can't access the value on a failed result");

        private Result(T value):base()
        {
            _value = value;
        }
        private Result(Error error) : base(error) { 
            _value = default(T)!;
        }
        private Result(List<Error> errors) : base(errors) {
            _value = default(T)!;
        }

        public static Result<T> Ok(T value) => new Result<T>(value);
        public static implicit operator Result<T>(T value) => Ok(value);
        public static Result<T> Fail(Error error) => new Result<T>(error);
        public static implicit operator Result<T>(Error error) => Fail(error);
        public static Result<T> Fail(List<Error> errors) => new Result<T>(errors);
        public static implicit operator Result<T>(List<Error> errors) => Fail(errors);


    }
}
