namespace Okta.Sdk.Abstractions
{
    public interface IChangeTrackable
    {
        void Reset();

        void MarkDirty(string key);

        void MarkClean(string key);

        object Difference { get; }
    }
}
