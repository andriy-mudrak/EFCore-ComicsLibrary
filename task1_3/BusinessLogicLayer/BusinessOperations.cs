using System;
using System.Linq;
using task1_3;
using task1_3.Tables;

namespace task1_3.BusinessLogicLayer
{
    class BusinessOperations
    {
        private UnitOfWork model;

        public BusinessOperations(UnitOfWork _model)
        {
            model = _model;
        }
        
        public void changePricePercent(Author auth, int percent)
        {
            using (var unitOfWork = new UnitOfWork(new ComixContext()))
            {
                foreach (Comix cm in auth.Comics)
                {
                    cm.Price = cm.Price * (1 + percent / 100.0);
                    unitOfWork.Comics.Update(cm);
                }
                unitOfWork.SaveChanges();
            }
        }

        
        public void transferRights(string _newAuthor, string _oldAuthor, string _comix)
        {
            var oldAuthor = model.Authors.GetAuthor(_oldAuthor).ToList();
            var newAuthor = model.Authors.GetAuthor(_newAuthor).ToList();
            var comix = model.Comics.GetComix(_comix).ToList();

            transferConfirmation(newAuthor[0],comix[0]);

        }
        public void transferConfirmation(Author author, Comix comix)
        {
            Comix updateComix = new Comix
            {
                Name = comix.Name,
                Price = comix.Price,

            };
            updateComix.Author = author;

            model.Comics.Remove(comix);
            model.Comics.Add(updateComix);
            model.SaveChanges();

        }
    }
}
