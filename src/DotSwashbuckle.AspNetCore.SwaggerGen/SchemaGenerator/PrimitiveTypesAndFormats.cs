using System;
using System.Collections.Generic;

namespace DotSwashbuckle.AspNetCore.SwaggerGen
{
    public static class CommonFormats
    {
        public static readonly IReadOnlyDictionary<Type, Tuple<DataType, string>> PrimitiveTypesAndFormats = new Dictionary<Type, Tuple<DataType, string>>
        {
            [typeof(bool)] = Tuple.Create(DataType.Boolean, (string)null),
            [typeof(bool?)] = Tuple.Create(DataType.Boolean, (string)null),
            [typeof(byte)] = Tuple.Create(DataType.Integer, "int32"),
            [typeof(byte?)] = Tuple.Create(DataType.Integer, "int32"),
            [typeof(sbyte)] = Tuple.Create(DataType.Integer, "int32"),
            [typeof(sbyte?)] = Tuple.Create(DataType.Integer, "int32"),
            [typeof(short)] = Tuple.Create(DataType.Integer, "int32"),
            [typeof(short?)] = Tuple.Create(DataType.Integer, "int32"),
            [typeof(ushort)] = Tuple.Create(DataType.Integer, "int32"),
            [typeof(ushort?)] = Tuple.Create(DataType.Integer, "int32"),
            [typeof(int)] = Tuple.Create(DataType.Integer, "int32"),
            [typeof(int?)] = Tuple.Create(DataType.Integer, "int32"),
            [typeof(uint)] = Tuple.Create(DataType.Integer, "int64"),
            [typeof(uint?)] = Tuple.Create(DataType.Integer, "int64"),
            [typeof(long)] = Tuple.Create(DataType.Integer, "int64"),
            [typeof(long?)] = Tuple.Create(DataType.Integer, "int64"),
            [typeof(ulong)] = Tuple.Create(DataType.Integer, "int64"),
            [typeof(ulong?)] = Tuple.Create(DataType.Integer, "int64"),
            [typeof(Int128)] = Tuple.Create(DataType.Integer, "int128"),
            [typeof(Int128?)] = Tuple.Create(DataType.Integer, "int128"),
            [typeof(UInt128)] = Tuple.Create(DataType.Integer, "int128"),
            [typeof(UInt128?)] = Tuple.Create(DataType.Integer, "int128"),
            [typeof(Version)] = Tuple.Create(DataType.String, (string)null),
            [typeof(float)] = Tuple.Create(DataType.Number, "float"),
            [typeof(float?)] = Tuple.Create(DataType.Number, "float"),
            [typeof(double)] = Tuple.Create(DataType.Number, "double"),
            [typeof(double?)] = Tuple.Create(DataType.Number, "double"),
            [typeof(decimal)] = Tuple.Create(DataType.Number, "double"),
            [typeof(decimal?)] = Tuple.Create(DataType.Number, "double"),
            [typeof(byte[])] = Tuple.Create(DataType.String, "byte"),
            [typeof(string)] = Tuple.Create(DataType.String, (string)null),
            [typeof(char)] = Tuple.Create(DataType.String, (string)null),
            [typeof(char?)] = Tuple.Create(DataType.String, (string)null),
            [typeof(DateTime)] = Tuple.Create(DataType.String, "date-time"),
            [typeof(DateTime?)] = Tuple.Create(DataType.String, "date-time"),
            [typeof(DateTimeOffset)] = Tuple.Create(DataType.String, "date-time"),
            [typeof(DateTimeOffset?)] = Tuple.Create(DataType.String, "date-time"),
            [typeof(Guid)] = Tuple.Create(DataType.String, "uuid"),
            [typeof(Guid?)] = Tuple.Create(DataType.String, "uuid"),
            [typeof(Uri)] = Tuple.Create(DataType.String, "uri"),
            [typeof(TimeSpan)] = Tuple.Create(DataType.String, "date-span"),
            [typeof(TimeSpan?)] = Tuple.Create(DataType.String, "date-span"),
            [typeof(DateOnly)] = Tuple.Create(DataType.String, "date"),
            [typeof(DateOnly?)] = Tuple.Create(DataType.String, "date"),
            [typeof(TimeOnly)] = Tuple.Create(DataType.String, "time"),
            [typeof(TimeOnly?)] = Tuple.Create(DataType.String, "time")
        };
    }
}
