public interface IUnlockStrategy
{
    bool CanUnlock(int yearOffset);
    void Unlock(int yearOffset);
}
