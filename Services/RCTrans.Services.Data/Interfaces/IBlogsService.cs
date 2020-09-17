namespace RCTrans.Services.Data.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using RCTrans.Data.Models;

    public interface IBlogsService
    {
        IEnumerable<T> GetAllArticles<T>();

        IEnumerable<T> GetTopThree<T>();

        T GetArticleById<T>(int id);

        Task<int> CreateAsync(string title, string content, string imageUrl);

        Task<int> UpdateAsync(int id, string title, string content, string imageUrl, DateTime createdOn);

        Task DeleteArticleById(int id);
    }
}