namespace HotChocolate.Types;

internal enum TypeStatus
{
    Uninitialized,
    Initialized,
    Named,
    Completed,
    MetadataCompleted,
    Executable,
    Finalized
}
