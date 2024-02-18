using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Mvc;

namespace DotSwashbuckle.AspNetCore.SwaggerGen
{
    public static class MemberInfoExtensions
    {
        public static ICollection<object> GetInlineAndMetadataAttributes(this MemberInfo memberInfo)
        {
            var attributes = memberInfo.GetCustomAttributes(true)
                .ToList();

            var metadataTypeAttribute = memberInfo.DeclaringType.GetCustomAttributes(true)
                .OfType<ModelMetadataTypeAttribute>()
                .FirstOrDefault();

            var metadataMemberInfo = metadataTypeAttribute?.MetadataType.GetMember(memberInfo.Name)
                .FirstOrDefault();

            if (metadataMemberInfo != null)
            {
                attributes.AddRange(metadataMemberInfo.GetCustomAttributes(true));
            }

            return attributes;
        }

        public static bool IsNonNullableReferenceType(this MemberInfo memberInfo)
        {
            var memberType = memberInfo.MemberType == MemberTypes.Field
                ? ((FieldInfo)memberInfo).FieldType
                : ((PropertyInfo)memberInfo).PropertyType;

            if (memberType.IsValueType) return false;

            var nullableAttribute = memberInfo.GetNullableAttribute();

            if (nullableAttribute == null)
            {
                return memberInfo.GetNullableFallbackValue();
            }

            if (nullableAttribute.NullableFlags.Length >= 1 && nullableAttribute.NullableFlags[0] == 1)
            {
                return true;
            }

            return false;
        }

        public static bool IsDictionaryValueNonNullable(this MemberInfo memberInfo)
        {
            var memberType = memberInfo.MemberType == MemberTypes.Field
                ? ((FieldInfo)memberInfo).FieldType
                : ((PropertyInfo)memberInfo).PropertyType;

            if (memberType.IsValueType) return false;

            var nullableAttribute = memberInfo.GetNullableAttribute();

            if (nullableAttribute == null)
            {
                return memberInfo.GetNullableFallbackValue();
            }

            if (nullableAttribute.NullableFlags.Length == 3 && nullableAttribute.NullableFlags[2] == 1)
            {
                return true;
            }

            return false;
        }

        private static NullableAttribute GetNullableAttribute(this MemberInfo memberInfo)
        {
            return memberInfo.GetCustomAttribute<NullableAttribute>();
        }

        private static bool GetNullableFallbackValue(this MemberInfo memberInfo)
        {
            var declaringTypes = memberInfo.DeclaringType.IsNested
                ? new Type[] { memberInfo.DeclaringType, memberInfo.DeclaringType.DeclaringType }
                : new Type[] { memberInfo.DeclaringType };

            // https://github.com/dotnet/roslyn/blob/main/docs/features/nullable-metadata.md
            // Check NullableContextAttribute first
            foreach (var declaringType in declaringTypes)
            {
                var attributes = declaringType.GetCustomAttributes(true);

                // NullableContextAttribute is optional
                var nullableContextAttribute = (NullableContextAttribute)attributes.FirstOrDefault(a => a is NullableContextAttribute);

                if (nullableContextAttribute != null)
                {
                    return nullableContextAttribute.Flag == 1;
                }
            }

            // Next check NullableAttribute
            foreach (var declaringType in declaringTypes)
            {
                var attributes = declaringType.GetCustomAttributes(true);
                var nullableAttribute = (NullableAttribute)attributes.FirstOrDefault(a => a is NullableAttribute);

                if (nullableAttribute != null)
                {
                    return nullableAttribute.NullableFlags.Length >= 1 && nullableAttribute.NullableFlags[0] == 1;
                }
            }

            return false;
        }
    }
}
