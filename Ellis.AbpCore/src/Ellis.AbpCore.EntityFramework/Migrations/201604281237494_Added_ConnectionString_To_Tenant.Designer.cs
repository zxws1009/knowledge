// <auto-generated />
namespace Ellis.AbpCore.Migrations
{
    using System.CodeDom.Compiler;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Migrations.Infrastructure;
    using System.Resources;
    
    [GeneratedCode("EntityFramework.Migrations", "6.1.3-40302")]
    public sealed partial class Added_ConnectionString_To_Tenant : IMigrationMetadata
    {
        private readonly ResourceManager Resources = new ResourceManager(typeof(Added_ConnectionString_To_Tenant));
        
        string IMigrationMetadata.Id
        {
            get { return "201604281237494_Added_ConnectionString_To_Tenant"; }
        }
        
        string IMigrationMetadata.Source
        {
            get { return null; }
        }
        
        string IMigrationMetadata.Target
        {
            get { return "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"; }
        }
    }
}
