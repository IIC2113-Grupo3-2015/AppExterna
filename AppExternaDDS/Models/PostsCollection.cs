using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppExternaDDS.Models
{
    public class PostsCollection : ObservableCollection<Post>
    {
        public void CopyFrom(IEnumerable<Post> posts)
        {
            this.Items.Clear();
            foreach (var p in posts)
            {
                this.Items.Add(p);
            }
            this.OnCollectionChanged(
                new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }
    }
}
