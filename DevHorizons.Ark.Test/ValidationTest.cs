namespace DevHorizons.Ark.Test
{
    using DevHorizons.Ark.Validation;
    using System.Collections;

    public class ValidationTest
    {
        #region Private Members
        enum Color
        {
            Red = 0,
            Green = 1,
            Blue = 2                
        }

        enum ParentManufacturer
        {
            GeneralMotors = 0,
            Stellantis = 1,
            FordMotors = 2,
            ToyotaMotor = 3,
            Volkswagen = 4,
            TataMotors = 5

        }


        enum CarManufacturer
        {
            Ford = 0,
            Buick = 1,
            Cadillac = 2,
            Chevrolet = 3,
            Chrysler = 4,
            Jeep = 5,
            Tesla = 6,
            Dodge = 7,
            GMC = 8,
            RAM = 9,
            Lincoln = 10,
            Nissan = 1

        }

        struct Employee
        {
            public string Name { get; set; }

            public DateOnly DateOfBirth { get; set; }
        }

        class Car
        {
            public Color Color { get; set; }

            public int Model { get; set; }

            public string Name { get; set; }

            public CarManufacturer Manufacturer { get; set; }

            public ParentManufacturer ParentManufacturer { get; set; }
        }

        class GenericClass<T>
        {
            public T Value { get; set; }
        }

        private bool TestGeneric<T>(T value)
        {
            return value.IsCollectionOrGenericCollection();
        }
        #endregion Private Members

        [Fact]
        public void TestIsSimpleType()
        {
            var dateTime = DateTime.Now;
            var dateOnly = DateOnly.FromDateTime(dateTime);
            var doubleValue = 4.5D;
            var floatValue = 4.5F;
            var decimalValue = 4.5M;
            var str = "Ahmad Gad";
            var c = 'C';
            var guid = Guid.NewGuid();
            var color = Color.Red; 
            byte b = 3;
            sbyte sb = -3;
            int integer = 15061980;
            ulong unsighnedLong = 353838489055;
            long longDigit = 201002501021;

            var employee = new Employee
            {
                Name = "Ahmad Gad",
                DateOfBirth = DateOnly.Parse("1980-06-15")
            };

            var car = new Car();
            var list = new List<int>{ };
            var array = new string[3];
            var arrayList = new ArrayList();
            var dic = new Dictionary<string, string>();
            var hashTable = new Hashtable();
            var hashSet = new HashSet<int>();
            var genericClass = new GenericClass<int>();

            Assert.False(dateTime.IsCompositeType());
            Assert.False(dateOnly.IsCompositeType());
            Assert.False(doubleValue.IsCompositeType());
            Assert.False(floatValue.IsCompositeType());
            Assert.False(decimalValue.IsCompositeType());
            Assert.False(str.IsCompositeType());
            Assert.False(c.IsCompositeType());
            Assert.False(guid.IsCompositeType());
            Assert.False(color.IsCompositeType());
            Assert.False(b.IsCompositeType());
            Assert.False(sb.IsCompositeType());
            Assert.False(dateOnly.IsCompositeType());
            Assert.False(integer.IsCompositeType());
            Assert.False(unsighnedLong.IsCompositeType());
            Assert.False(longDigit.IsCompositeType());


            Assert.True(employee.IsCompositeType());
            Assert.True(car.IsCompositeType());
            Assert.True(list.IsCompositeType());
            Assert.True(array.IsCompositeType());

            Assert.True(arrayList.IsCompositeType());
            Assert.True(dic.IsCompositeType());
            Assert.True(hashTable.IsCompositeType());
            Assert.True(hashSet.IsCompositeType());
            Assert.True(genericClass.IsCompositeType());
            list = null;
            var ex = Record.Exception(() => list.IsCompositeType());
            Assert.NotNull(ex);
            Assert.IsType<ArgumentNullException>(ex);
        }

        [Fact]
        public void TestIsStruct()
        {
            var dateTime = DateTime.Now;
            var dateOnly = DateOnly.FromDateTime(dateTime);
            var doubleValue = 4.5D;
            var floatValue = 4.5F;
            var decimalValue = 4.5M;
            var str = "Ahmad Gad";
            var c = 'C';
            var guid = Guid.NewGuid();
            var color = Color.Red;
            byte b = 3;
            sbyte sb = -3;
            int integer = 15061980;
            ulong unsighnedLong = 353838489055;
            long longDigit = 201002501021;

            var employee = new Employee
            {
                Name = "Ahmad Gad",
                DateOfBirth = DateOnly.Parse("1980-06-15")
            };


            var car = new Car();
            var list = new List<int> { };
            var array = new string[3];
            var arrayList = new ArrayList();
            var dic = new Dictionary<string, string>();
            var hashTable = new Hashtable();
            var hashSet = new HashSet<int>();
            var genericClass = new GenericClass<int>();

            Assert.False(dateTime.IsStruct());
            Assert.False(dateOnly.IsStruct());
            Assert.False(doubleValue.IsStruct());
            Assert.False(floatValue.IsStruct());
            Assert.False(decimalValue.IsStruct());
            Assert.False(str.IsStruct());
            Assert.False(c.IsStruct());
            Assert.False(guid.IsStruct());
            Assert.False(color.IsStruct());
            Assert.False(b.IsStruct());
            Assert.False(sb.IsStruct());
            Assert.False(dateOnly.IsStruct());
            Assert.False(integer.IsStruct());
            Assert.False(unsighnedLong.IsStruct());
            Assert.False(longDigit.IsStruct());


            Assert.True(employee.IsStruct());

            Assert.False(car.IsStruct());
            Assert.False(list.IsStruct());
            Assert.False(array.IsStruct());

            Assert.False(arrayList.IsStruct());
            Assert.False(dic.IsStruct());
            Assert.False(hashTable.IsStruct());
            Assert.False(hashSet.IsStruct());
            Assert.False(genericClass.IsStruct());
            list = null;
            var ex = Record.Exception(() => list.IsStruct());
            Assert.NotNull(ex);
            Assert.IsType<ArgumentNullException>(ex);
        }

        [Fact]
        public void TestIsCompositeType()
        {
            var dateTime = DateTime.Now;
            var dateOnly = DateOnly.FromDateTime(dateTime);
            var doubleValue = 4.5D;
            var floatValue = 4.5F;
            var decimalValue = 4.5M;
            var str = "Ahmad Gad";
            var c = 'C';
            var guid = Guid.NewGuid();
            var color = Color.Red;
            byte b = 3;
            sbyte sb = -3;
            int integer = 15061980;
            ulong unsighnedLong = 353838489055;
            long longDigit = 201002501021;

            var employee = new Employee
            {
                Name = "Ahmad Gad",
                DateOfBirth = DateOnly.Parse("1980-06-15")
            };

            var car = new Car();
            var list = new List<int> { };
            var array = new string[3];
            var arrayList = new ArrayList();
            var dic = new Dictionary<string, string>();
            var hashTable = new Hashtable();
            var hashSet = new HashSet<int>();
            var genericClass = new GenericClass<int>();

            Assert.False(dateTime.GetType().IsCompositeType());
            Assert.False(dateOnly.GetType().IsCompositeType());
            Assert.False(doubleValue.GetType().IsCompositeType());
            Assert.False(floatValue.GetType().IsCompositeType());
            Assert.False(decimalValue.GetType().IsCompositeType());
            Assert.False(str.GetType().IsCompositeType());
            Assert.False(c.GetType().IsCompositeType());
            Assert.False(guid.GetType().IsCompositeType());
            Assert.False(color.GetType().IsCompositeType());
            Assert.False(b.GetType().IsCompositeType());
            Assert.False(sb.GetType().IsCompositeType());
            Assert.False(dateOnly.GetType().IsCompositeType());
            Assert.False(integer.GetType().IsCompositeType());
            Assert.False(unsighnedLong.GetType().IsCompositeType());
            Assert.False(longDigit.GetType().IsCompositeType());


            Assert.True(employee.GetType().IsCompositeType());
            Assert.True(car.GetType().IsCompositeType());
            Assert.True(list.GetType().IsCompositeType());
            Assert.True(array.GetType().IsCompositeType());

            Assert.True(arrayList.GetType().IsCompositeType());
            Assert.True(dic.GetType().IsCompositeType());
            Assert.True(hashTable.GetType().IsCompositeType());
            Assert.True(hashSet.GetType().IsCompositeType());
            Assert.True(genericClass.GetType().IsCompositeType());    
        }


        [Fact]
        public void TestIsIsCollection()
        {
            var dateTime = DateTime.Now;
            var dateOnly = DateOnly.FromDateTime(dateTime);
            var doubleValue = 4.5D;
            var floatValue = 4.5F;
            var decimalValue = 4.5M;
            var str = "Ahmad Gad";
            var c = 'C';
            var guid = Guid.NewGuid();
            var color = Color.Red;
            byte b = 3;
            sbyte sb = -3;
            int integer = 15061980;
            ulong unsighnedLong = 353838489055;
            long longDigit = 201002501021;

            var employee = new Employee
            {
                Name = "Ahmad Gad",
                DateOfBirth = DateOnly.Parse("1980-06-15")
            };

            var car = new Car();

            var list = new List<int> { };
            var array = new string[3];
            var arrayList = new ArrayList();
            var dic = new Dictionary<string, string>();
            var hashTable = new Hashtable();
            var hashSet = new HashSet<int>();
            var genericClass = new GenericClass<int>();

            Assert.False(dateTime.IsCollectionOrGenericCollection());
            Assert.False(dateOnly.IsCollectionOrGenericCollection());
            Assert.False(doubleValue.IsCollectionOrGenericCollection());
            Assert.False(floatValue.IsCollectionOrGenericCollection());
            Assert.False(decimalValue.IsCollectionOrGenericCollection());
            Assert.False(str.IsCollectionOrGenericCollection());
            Assert.False(c.IsCollectionOrGenericCollection());
            Assert.False(guid.IsCollectionOrGenericCollection());
            Assert.False(color.IsCollectionOrGenericCollection());
            Assert.False(b.IsCollectionOrGenericCollection());
            Assert.False(sb.IsCollectionOrGenericCollection());
            Assert.False(dateOnly.IsCollectionOrGenericCollection());
            Assert.False(integer.IsCollectionOrGenericCollection());
            Assert.False(unsighnedLong.IsCollectionOrGenericCollection());
            Assert.False(longDigit.IsCollectionOrGenericCollection());


            Assert.False(employee.IsCollectionOrGenericCollection());
            Assert.False(car.IsCollectionOrGenericCollection());
            Assert.False(this.TestGeneric<DateTime>(dateTime));
            Assert.False(genericClass.IsCollectionOrGenericCollection());

            Assert.True(list.IsCollectionOrGenericCollection());
            Assert.True(array.IsCollectionOrGenericCollection());

            Assert.True(arrayList.IsCollectionOrGenericCollection());
            Assert.True(dic.IsCollectionOrGenericCollection());
            Assert.True(hashTable.IsCollectionOrGenericCollection());
            Assert.True(hashSet.IsCollectionOrGenericCollection());

            list = null;
            var ex = Record.Exception(() => list.IsCollectionOrGenericCollection());
            Assert.NotNull(ex);
            Assert.IsType<ArgumentNullException>(ex);
        }

        [Fact]
        public void TestIsSimpleValueType()
        {
            var dateTime = DateTime.Now;
            var dateOnly = DateOnly.FromDateTime(dateTime);
            var doubleValue = 4.5D;
            var floatValue = 4.5F;
            var decimalValue = 4.5M;
            var str = "Ahmad Gad";
            var c = 'C';
            var guid = Guid.NewGuid();
            var color = Color.Red;
            byte b = 3;
            sbyte sb = -3;
            int integer = 15061980;
            ulong unsighnedLong = 353838489055;
            long longDigit = 201002501021;

            var employee = new Employee
            {
                Name = "Ahmad Gad",
                DateOfBirth = DateOnly.Parse("1980-06-15")
            };

            var car = new Car();

            var list = new List<int> { };
            var array = new string[3];
            var arrayList = new ArrayList();
            var dic = new Dictionary<string, string>();
            var hashTable = new Hashtable();
            var hashSet = new HashSet<int>();
            var genericClass = new GenericClass<int>();

            Assert.True(dateTime.IsSimpleType());
            Assert.True(dateOnly.IsSimpleType());
            Assert.True(doubleValue.IsSimpleType());
            Assert.True(floatValue.IsSimpleType());
            Assert.True(decimalValue.IsSimpleType());
            Assert.True(str.IsSimpleType());
            Assert.True(c.IsSimpleType());
            Assert.True(guid.IsSimpleType());
            Assert.True(b.IsSimpleType());
            Assert.True(sb.IsSimpleType());
            Assert.True(dateOnly.IsSimpleType());
            Assert.True(integer.IsSimpleType());
            Assert.True(unsighnedLong.IsSimpleType());
            Assert.True(longDigit.IsSimpleType());

            Assert.True(color.IsSimpleType());


            Assert.False(employee.IsSimpleType());
            Assert.False(car.IsSimpleType());
            Assert.False(genericClass.IsSimpleType());
            Assert.False(list.IsSimpleType());
            Assert.False(array.IsSimpleType());

            Assert.False(arrayList.IsSimpleType());
            Assert.False(dic.IsSimpleType());
            Assert.False(hashTable.IsSimpleType());
            Assert.False(hashSet.IsSimpleType());

           
            list = null;

            var ex = Record.Exception(() => list.IsSimpleType());
            Assert.NotNull(ex);
            Assert.IsType<ArgumentNullException>(ex);
        }

        [Fact]
        public void TestIsSingleConcreteClass()
        {
            var dateTime = DateTime.Now;
            var dateOnly = DateOnly.FromDateTime(dateTime);
            var doubleValue = 4.5D;
            var floatValue = 4.5F;
            var decimalValue = 4.5M;
            var str = "Ahmad Gad";
            var c = 'C';
            var guid = Guid.NewGuid();
            var color = Color.Red;
            byte b = 3;
            sbyte sb = -3;
            int integer = 15061980;
            ulong unsighnedLong = 353838489055;
            long longDigit = 201002501021;

            var employee = new Employee
            {
                Name = "Ahmad Gad",
                DateOfBirth = DateOnly.Parse("1980-06-15")
            };

            var car = new Car();

            var list = new List<int> { };
            var array = new string[3];
            var arrayList = new ArrayList();
            var dic = new Dictionary<string, string>();
            var hashTable = new Hashtable();
            var hashSet = new HashSet<int>();
            var genericClass = new GenericClass<int>();

            Assert.False(dateTime.IsSingleConcreteClass());
            Assert.False(dateOnly.IsSingleConcreteClass());
            Assert.False(doubleValue.IsSingleConcreteClass());
            Assert.False(floatValue.IsSingleConcreteClass());
            Assert.False(decimalValue.IsSingleConcreteClass());
            Assert.False(str.IsSingleConcreteClass());
            Assert.False(c.IsSingleConcreteClass());
            Assert.False(guid.IsSingleConcreteClass());
            Assert.False(b.IsSingleConcreteClass());
            Assert.False(sb.IsSingleConcreteClass());
            Assert.False(dateOnly.IsSingleConcreteClass());
            Assert.False(integer.IsSingleConcreteClass());
            Assert.False(unsighnedLong.IsSingleConcreteClass());
            Assert.False(longDigit.IsSingleConcreteClass());

            Assert.False(color.IsSingleConcreteClass());


            Assert.False(employee.IsSingleConcreteClass());
            Assert.True(car.IsSingleConcreteClass());
            Assert.True(genericClass.IsSingleConcreteClass());
            Assert.False(list.IsSingleConcreteClass());
            Assert.False(array.IsSingleConcreteClass());

            Assert.False(arrayList.IsSingleConcreteClass());
            Assert.False(dic.IsSingleConcreteClass());
            Assert.False(hashTable.IsSingleConcreteClass());
            Assert.False(hashSet.IsSingleConcreteClass());


            list = null;

            var ex = Record.Exception(() => list.IsSingleConcreteClass());
            Assert.NotNull(ex);
            Assert.IsType<ArgumentNullException>(ex);
        }

        [Fact]
        public void TestIsCollection()
        {
            var dateTime = DateTime.Now;
            var dateOnly = DateOnly.FromDateTime(dateTime);
            var doubleValue = 4.5D;
            var floatValue = 4.5F;
            var decimalValue = 4.5M;
            var str = "Ahmad Gad";
            var c = 'C';
            var guid = Guid.NewGuid();
            var color = Color.Red;
            byte b = 3;
            sbyte sb = -3;
            int integer = 15061980;
            ulong unsighnedLong = 353838489055;
            long longDigit = 201002501021;

            var employee = new Employee
            {
                Name = "Ahmad Gad",
                DateOfBirth = DateOnly.Parse("1980-06-15")
            };

            var car = new Car();

            var list = new List<int> { };
            var array = new string[3];
            var arrayList = new ArrayList();
            var dic = new Dictionary<string, string>();
            var hashTable = new Hashtable();
            var hashSet = new HashSet<int>();
            var genericClass = new GenericClass<int>();

            Assert.False(dateTime.IsCollection());
            Assert.False(dateOnly.IsCollection());
            Assert.False(doubleValue.IsCollection());
            Assert.False(floatValue.IsCollection());
            Assert.False(decimalValue.IsCollection());
            Assert.False(str.IsCollection());
            Assert.False(c.IsCollection());
            Assert.False(guid.IsCollection());
            Assert.False(b.IsCollection());
            Assert.False(sb.IsCollection());
            Assert.False(dateOnly.IsCollection());
            Assert.False(integer.IsCollection());
            Assert.False(unsighnedLong.IsCollection());
            Assert.False(longDigit.IsCollection());

            Assert.False(color.IsCollection());


            Assert.False(employee.IsCollection());
            Assert.False(car.IsCollection());
            Assert.False(genericClass.IsCollection());

            Assert.True(list.IsCollection());
            Assert.True(array.IsCollection());
            Assert.True(arrayList.IsCollection());
            Assert.True(dic.IsCollection());
            Assert.True(hashTable.IsCollection());
            Assert.False(hashSet.IsCollection());


            list = null;

            var ex = Record.Exception(() => list.IsCollection());
            Assert.NotNull(ex);
            Assert.IsType<ArgumentNullException>(ex);
        }

        [Fact]
        public void TestIsGenericCollection()
        {
            var dateTime = DateTime.Now;
            var dateOnly = DateOnly.FromDateTime(dateTime);
            var doubleValue = 4.5D;
            var floatValue = 4.5F;
            var decimalValue = 4.5M;
            var str = "Ahmad Gad";
            var c = 'C';
            var guid = Guid.NewGuid();
            var color = Color.Red;
            byte b = 3;
            sbyte sb = -3;
            int integer = 15061980;
            ulong unsighnedLong = 353838489055;
            long longDigit = 201002501021;

            var employee = new Employee
            {
                Name = "Ahmad Gad",
                DateOfBirth = DateOnly.Parse("1980-06-15")
            };

            var car = new Car();

            var list = new List<int> { };
            var array = new string[3];
            var arrayList = new ArrayList();
            var dic = new Dictionary<string, string>();
            var hashTable = new Hashtable();
            var hashSet = new HashSet<int>();
            var genericClass = new GenericClass<int>();

            Assert.False(dateTime.IsGenericCollection());
            Assert.False(dateOnly.IsGenericCollection());
            Assert.False(doubleValue.IsGenericCollection());
            Assert.False(floatValue.IsGenericCollection());
            Assert.False(decimalValue.IsGenericCollection());
            Assert.False(str.IsGenericCollection());
            Assert.False(c.IsGenericCollection());
            Assert.False(guid.IsGenericCollection());
            Assert.False(b.IsGenericCollection());
            Assert.False(sb.IsGenericCollection());
            Assert.False(dateOnly.IsGenericCollection());
            Assert.False(integer.IsGenericCollection());
            Assert.False(unsighnedLong.IsGenericCollection());
            Assert.False(longDigit.IsGenericCollection());

            Assert.False(color.IsGenericCollection());


            Assert.False(employee.IsGenericCollection());
            Assert.False(car.IsGenericCollection());
            Assert.False(genericClass.IsGenericCollection());

            Assert.True(list.IsGenericCollection());
            Assert.True(array.IsGenericCollection());
            Assert.False(arrayList.IsGenericCollection());
            Assert.True(dic.IsGenericCollection());
            Assert.False(hashTable.IsGenericCollection());
            Assert.True(hashSet.IsGenericCollection());

            list = null;

            var ex = Record.Exception(() => list.IsGenericCollection());
            Assert.NotNull(ex);
            Assert.IsType<ArgumentNullException>(ex);
        }

        [Fact]
        public void TestIsCollectionOrGenericCollection()
        {
            var dateTime = DateTime.Now;
            var dateOnly = DateOnly.FromDateTime(dateTime);
            var doubleValue = 4.5D;
            var floatValue = 4.5F;
            var decimalValue = 4.5M;
            var str = "Ahmad Gad";
            var c = 'C';
            var guid = Guid.NewGuid();
            var color = Color.Red;
            byte b = 3;
            sbyte sb = -3;
            int integer = 15061980;
            ulong unsighnedLong = 353838489055;
            long longDigit = 201002501021;

            var employee = new Employee
            {
                Name = "Ahmad Gad",
                DateOfBirth = DateOnly.Parse("1980-06-15")
            };

            var car = new Car();

            var list = new List<int> { };
            var array = new string[3];
            var arrayList = new ArrayList();
            var dic = new Dictionary<string, string>();
            var hashTable = new Hashtable();
            var hashSet = new HashSet<int>();
            var genericClass = new GenericClass<int>();

            Assert.False(dateTime.IsCollectionOrGenericCollection());
            Assert.False(dateOnly.IsCollectionOrGenericCollection());
            Assert.False(doubleValue.IsCollectionOrGenericCollection());
            Assert.False(floatValue.IsCollectionOrGenericCollection());
            Assert.False(decimalValue.IsCollectionOrGenericCollection());
            Assert.False(str.IsCollectionOrGenericCollection());
            Assert.False(c.IsCollectionOrGenericCollection());
            Assert.False(guid.IsCollectionOrGenericCollection());
            Assert.False(b.IsCollectionOrGenericCollection());
            Assert.False(sb.IsCollectionOrGenericCollection());
            Assert.False(dateOnly.IsCollectionOrGenericCollection());
            Assert.False(integer.IsCollectionOrGenericCollection());
            Assert.False(unsighnedLong.IsCollectionOrGenericCollection());
            Assert.False(longDigit.IsCollectionOrGenericCollection());

            Assert.False(color.IsCollectionOrGenericCollection());


            Assert.False(employee.IsCollectionOrGenericCollection());
            Assert.False(car.IsCollectionOrGenericCollection());
            Assert.False(genericClass.IsCollectionOrGenericCollection());

            Assert.True(list.IsCollectionOrGenericCollection());
            Assert.True(array.IsCollectionOrGenericCollection());
            Assert.True(arrayList.IsCollectionOrGenericCollection());
            Assert.True(dic.IsCollectionOrGenericCollection());
            Assert.True(hashTable.IsCollectionOrGenericCollection());
            Assert.True(hashSet.IsCollectionOrGenericCollection());

            list = null;

            var ex = Record.Exception(() => list.IsCollectionOrGenericCollection());
            Assert.NotNull(ex);
            Assert.IsType<ArgumentNullException>(ex);
        }


        [Fact]
        public void TestIsCollectionOrGenericCollectionType()
        {
            var dateTime = DateTime.Now;
            var dateOnly = DateOnly.FromDateTime(dateTime);
            var doubleValue = 4.5D;
            var floatValue = 4.5F;
            var decimalValue = 4.5M;
            var str = "Ahmad Gad";
            var c = 'C';
            var guid = Guid.NewGuid();
            var color = Color.Red;
            byte b = 3;
            sbyte sb = -3;
            int integer = 15061980;
            ulong unsighnedLong = 353838489055;
            long longDigit = 201002501021;

            var employee = new Employee
            {
                Name = "Ahmad Gad",
                DateOfBirth = DateOnly.Parse("1980-06-15")
            };

            var car = new Car();

            var list = new List<int> { };
            var array = new string[3];
            var arrayList = new ArrayList();
            var dic = new Dictionary<string, string>();
            var hashTable = new Hashtable();
            var hashSet = new HashSet<int>();
            var genericClass = new GenericClass<int>();

            Assert.False(dateTime.GetType().IsCollectionOrGenericCollection());
            Assert.False(dateOnly.GetType().IsCollectionOrGenericCollection());
            Assert.False(doubleValue.GetType().IsCollectionOrGenericCollection());
            Assert.False(floatValue.GetType().IsCollectionOrGenericCollection());
            Assert.False(decimalValue.GetType().IsCollectionOrGenericCollection());
            Assert.False(str.GetType().IsCollectionOrGenericCollection());
            Assert.False(c.GetType().IsCollectionOrGenericCollection());
            Assert.False(guid.GetType().IsCollectionOrGenericCollection());
            Assert.False(b.GetType().IsCollectionOrGenericCollection());
            Assert.False(sb.GetType().IsCollectionOrGenericCollection());
            Assert.False(dateOnly.GetType().IsCollectionOrGenericCollection());
            Assert.False(integer.GetType().IsCollectionOrGenericCollection());
            Assert.False(unsighnedLong.GetType().IsCollectionOrGenericCollection());
            Assert.False(longDigit.GetType().IsCollectionOrGenericCollection());

            Assert.False(color.GetType().IsCollectionOrGenericCollection());


            Assert.False(employee.GetType().IsCollectionOrGenericCollection());
            Assert.False(car.GetType().IsCollectionOrGenericCollection());
            Assert.False(genericClass.GetType().IsCollectionOrGenericCollection());

            Assert.True(list.GetType().IsCollectionOrGenericCollection());
            Assert.True(array.GetType().IsCollectionOrGenericCollection());
            Assert.True(arrayList.GetType().IsCollectionOrGenericCollection());
            Assert.True(dic.GetType().IsCollectionOrGenericCollection());
            Assert.True(hashTable.GetType().IsCollectionOrGenericCollection());
            Assert.True(hashSet.GetType().IsCollectionOrGenericCollection());
        }

        [Fact]
        public void TestIsConcreteClassCollection()
        {
         
            var list = new List<int> { };
            var array = new string[3];
            var arrayList = new ArrayList();
            var dic = new Dictionary<string, string>();
            var hashTable = new Hashtable();
            var hashSet = new HashSet<int>();
            var genericClass = new GenericClass<int>();

            Assert.False(list.IsCollectionOfConcreteClass());
            Assert.False(array.IsCollectionOfConcreteClass());

            Assert.False(arrayList.IsCollectionOfConcreteClass());
            Assert.False(dic.IsCollectionOfConcreteClass());
            Assert.False(hashTable.IsCollectionOfConcreteClass());
            Assert.False(hashSet.IsCollectionOfConcreteClass());


            list = null;

            var ex = Record.Exception(() => list.IsCollectionOfConcreteClass());
            Assert.NotNull(ex);
            Assert.IsType<ArgumentNullException>(ex);


            var carList = new List<Car> { };
            var carArray = new Car[3];
            var hashSetCar = new HashSet<Car>();
            var dicCar = new Dictionary<string, Car>();
 
            Assert.True(carList.IsCollectionOfConcreteClass());
            Assert.True(carArray.IsCollectionOfConcreteClass());
            Assert.True(hashSetCar.IsCollectionOfConcreteClass());
            Assert.False(dicCar.IsCollectionOfConcreteClass());

            hashSetCar = null;

            ex = Record.Exception(() => hashSetCar.IsCollectionOfConcreteClass());
            Assert.NotNull(ex);
            Assert.IsType<ArgumentNullException>(ex);
        }
    }
}
