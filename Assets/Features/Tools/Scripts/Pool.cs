using System.Collections.Generic;

public abstract class Pool<T>
{
    private readonly Queue<T> _itemQueue;
    private readonly int _defaultItemCount;

    private int _cachedItemsCount;

    protected Pool(int defaultItemCount)
    {
        _itemQueue = new Queue<T>();
        _defaultItemCount = defaultItemCount;
    }

    public abstract T CreateItem();
    public abstract void HandleItemGet(T item);
    public abstract void HandleItemRelease(T item);
    public abstract void HandleItemDestroy(T item);

    public void Prewarm()
    {
        for (int i = 0; i < _defaultItemCount; i++)
        {
            CacheNewItem();
        }
    }

    public T Get()
    {
        if (_itemQueue.Count == 0)
        {
            CacheNewItem();
        }

        _cachedItemsCount--;

        var item = _itemQueue.Dequeue();

        HandleItemGet(item);

        return item;
    }

    public void Release(T item)
    {
        HandleItemRelease(item);

        if (_cachedItemsCount >= _defaultItemCount)
        {
            HandleItemDestroy(item);

            _cachedItemsCount--;
        }
        else
        {
            CacheItem(item);
        }
        
    }

    private void CacheNewItem()
    {
        CacheItem(CreateItem());
    }

    private void CacheItem(T item)
    {
        _itemQueue.Enqueue(item);

        _cachedItemsCount++;
    }
}
