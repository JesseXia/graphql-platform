# GenerateSource_BatchDataLoader_MatchesSnapshot

## BookNode.WaAdMHmlGJHjtEI4nqY7WA.hc.g.cs

```csharp
// <auto-generated/>

#nullable enable
#pragma warning disable

using System;
using System.Runtime.CompilerServices;
using HotChocolate;
using HotChocolate.Types;
using HotChocolate.Execution.Configuration;
using Microsoft.Extensions.DependencyInjection;
using HotChocolate.Internal;

namespace TestNamespace
{
    internal static partial class BookNode
    {
        internal static void Initialize(global::HotChocolate.Types.IObjectTypeDescriptor<global::TestNamespace.Book> descriptor)
        {
            var thisType = typeof(global::TestNamespace.BookNode);
            var bindingResolver = descriptor.Extend().Context.ParameterBindingResolver;
            var resolvers = new __Resolvers();

            var naming = descriptor.Extend().Context.Naming;
            var ignoredFields = new global::System.Collections.Generic.HashSet<string>();
            ignoredFields.Add(naming.GetMemberName("AuthorId", global::HotChocolate.Types.MemberKind.ObjectField));

            foreach(string fieldName in ignoredFields)
            {
                descriptor.Field(fieldName).Ignore();
            }

            descriptor
                .Field(thisType.GetMember("GetAuthorAsync", global::HotChocolate.Utilities.ReflectionUtils.StaticMemberFlags)[0])
                .ExtendWith(static (c, r) =>
                {
                    c.Configuration.SetSourceGeneratorFlags();
                    c.Configuration.Resolvers = r.GetAuthorAsync();
                },
                resolvers);

            Configure(descriptor);
        }

        static partial void Configure(global::HotChocolate.Types.IObjectTypeDescriptor<global::TestNamespace.Book> descriptor);

        private sealed class __Resolvers
        {
            public HotChocolate.Resolvers.FieldResolverDelegates GetAuthorAsync()
                => new global::HotChocolate.Resolvers.FieldResolverDelegates(resolver: GetAuthorAsync);

            private async global::System.Threading.Tasks.ValueTask<global::System.Object?> GetAuthorAsync(global::HotChocolate.Resolvers.IResolverContext context)
            {
                var args0 = context.Parent<global::TestNamespace.Book>();
                var args1 = context.RequestAborted;
                var result = await global::TestNamespace.BookNode.GetAuthorAsync(args0, args1);
                return result;
            }
        }
    }
}


```

## HotChocolateTypeModule.735550c.g.cs

```csharp
// <auto-generated/>

#nullable enable
#pragma warning disable

using System;
using System.Runtime.CompilerServices;
using HotChocolate;
using HotChocolate.Types;
using HotChocolate.Execution.Configuration;

namespace Microsoft.Extensions.DependencyInjection
{
    public static partial class TestsTypesRequestExecutorBuilderExtensions
    {
        public static IRequestExecutorBuilder AddTestsTypes(this IRequestExecutorBuilder builder)
        {
            builder.ConfigureDescriptorContext(ctx => ctx.TypeConfiguration.TryAdd<global::TestNamespace.Book>(
                "Tests::TestNamespace.BookNode",
                () => global::TestNamespace.BookNode.Initialize));
            builder.AddType<ObjectType<global::TestNamespace.Book>>();
            return builder;
        }
    }
}

```

