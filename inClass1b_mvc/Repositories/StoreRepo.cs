using inClass1b_mvc.Models.FoodStore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace inClass1b_mvc.Repositories
{
    public class StoreRepo
    {
        private FoodStoreContext db;

        public StoreRepo(FoodStoreContext db)
        {
            this.db = db;
        }

        public Store Get(string branch)
        {
            return db.Store.FirstOrDefault(s => s.Branch == branch);
        }
        public bool Update(string branch, string region)
        {
            Store store = Get(branch);
            store.Region = region;
            db.SaveChanges(); // Commit changes to database.

            // Error handling code goes here.
            return true;
        }


    }

}
