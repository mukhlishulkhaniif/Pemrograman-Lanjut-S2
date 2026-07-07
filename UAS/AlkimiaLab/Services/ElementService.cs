using AlkimiaLab.Models;
using AlkimiaLab.Repositories;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace AlkimiaLab.Services
{
        
    public class ElementService
    {

        private readonly ElementRepository repository;

        public ElementService()
        {
            repository = new ElementRepository();
        }

        public int GetTotalElementCount()
        {
            return repository.GetTotalElementCount();
        }

        public List<Element> GetAllElements()
        {
            return repository.GetAllElements();
        }

        public List<Element> GetDiscoveredElements(int userId)
        {
            return repository.GetDiscoveredElements(userId);
        }

        public void EnsureBaseElementsUnlocked(int userId, List<int> baseElementIds)
        {
            foreach (var elementId in baseElementIds)
            {
                if (!repository.ProgressExists(userId, elementId))
                {
                    repository.UnlockBaseElement(userId, elementId);
                }
            }
        }

        public bool MarkAsDiscovered(int userId, int elementId)
        {
            if (repository.IsDiscovered(userId, elementId))
            {
                return false;
            }

            repository.SaveDiscovery(userId, elementId);

            return true;
        }

    }
}