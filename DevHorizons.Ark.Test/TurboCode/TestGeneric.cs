namespace DevHorizons.Ark.Test
{
    using Exceptions;
    using Internal;
    using TurboCode;

    public class TestGeneric
    {
        [Fact]
        public void TestGetGenericTypeCollection()
        {
            var list = new List<int> { };
            var array = new string[3];
            var hashSet = new HashSet<Employee>();
            var dic = new Dictionary<string, Car>();

            Assert.Equal(typeof(int), list.GetGenericType());
            Assert.Equal(typeof(int), list.GetGenericType(0));
            Assert.Equal(typeof(string), array.GetGenericType());
            Assert.Equal(typeof(string), array.GetGenericType(0));

            Assert.Null(array.GetGenericType(4));
            Assert.Null(list.GetGenericType(4));

            Assert.Equal(typeof(Employee), hashSet.GetGenericType());

            Assert.Equal(typeof(string), dic.GetGenericType());
            Assert.Equal(typeof(string), dic.GetGenericType(0));
            Assert.Equal(typeof(Car), dic.GetGenericType(1));

            var ex = Record.Exception(() => list.GetGenericType(-1));
            Assert.NotNull(ex);
            Assert.IsType<ArgumentException>(ex);
            var argumentException = ex as ArgumentException;
            Assert.NotNull(argumentException);
            Assert.NotNull(argumentException.DateTime);
            Assert.NotNull(argumentException.StackFrame);
            Assert.NotNull(argumentException.StackTraceObject);
            Assert.Null(argumentException.ConflictArguement);
            Assert.Equal("index", argumentException.Origin.Argument);
            Assert.Equal(nameof(Generic.GetGenericType), argumentException.Origin.Method);
            Assert.Equal(typeof(Generic).FullName, argumentException.Origin.Class);
            Assert.Equal(typeof(Generic).Assembly.FullName, argumentException.Origin.Assembly);
            var expectedExceptionCode = ArgumentExceptionCode.OutRange | ArgumentExceptionCode.InvalidValue;

            Assert.Equal(expectedExceptionCode, argumentException.ExceptionCode);
            Assert.Equal((int)expectedExceptionCode, argumentException.Code);
        }

        [Fact]
        public void TestGetGenericTypeNonGenericCollection()
        {
            var arrayTwoDim = new ulong[3, 2];
            var genericClass = new GenericClass<Color, Employee, CarManufacturer, string>();

            Assert.Equal(typeof(ulong), arrayTwoDim.GetGenericType());
            Assert.Null(arrayTwoDim.GetGenericType(2));


            Assert.Equal(typeof(Color), genericClass.GetGenericType());
            Assert.Equal(typeof(Color), genericClass.GetGenericType(0));
            Assert.Equal(typeof(Employee), genericClass.GetGenericType(1));
            Assert.Equal(typeof(CarManufacturer), genericClass.GetGenericType(2));
            Assert.Equal(typeof(string), genericClass.GetGenericType(3));

            Assert.Null(genericClass.GetGenericType(4));
            Assert.Null(genericClass.GetGenericType(1000));

            var ex = Record.Exception(() => genericClass.GetGenericType(-1));
            Assert.NotNull(ex);
            Assert.IsType<ArgumentException>(ex);
            var argumentException = ex as ArgumentException;
            Assert.NotNull(argumentException);
            Assert.Null(argumentException.ConflictArguement);
            Assert.Equal("index", argumentException.Origin.Argument);
            Assert.Equal(nameof(Generic.GetGenericType), argumentException.Origin.Method);
            Assert.Equal(typeof(Generic).FullName, argumentException.Origin.Class);
            Assert.Equal(typeof(Generic).Assembly.FullName, argumentException.Origin.Assembly);
            var expectedExceptionCode = ArgumentExceptionCode.OutRange | ArgumentExceptionCode.InvalidValue;
            Assert.Equal(expectedExceptionCode, argumentException.ExceptionCode);
            Assert.Equal((int)expectedExceptionCode, argumentException.Code);

            genericClass = null;
            ex = Record.Exception(() => genericClass.GetGenericType());
            Assert.NotNull(ex);
            Assert.IsType<ArgumentNullException>(ex);
        }
    }
}
