#pragma warning disable CS9113

using Xunit;
using Xunit.Sdk;

namespace Blakroq.Tests;

[TraitDiscoverer("Xunit.Sdk.TraitDiscoverer", "xunit.core")]
[AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
public class UnitTestAttribute(string name = "Category", string value = "unit") : FactAttribute, ITraitAttribute { }
