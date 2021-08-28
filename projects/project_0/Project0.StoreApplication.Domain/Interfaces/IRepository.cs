using System.Collections.Generic;

namespace Project0.StoreApplication.Domain.Interfaces
{
  public interface IRepository<T> where T : class
  {
    bool Insert(T entry);

    T Update();

    List<T> Select();

    bool Delete();
  }
}