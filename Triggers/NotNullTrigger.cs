using System;
namespace FoodOrderingApp.Triggers
{
    public class NotNullTrigger : TriggerAction<Entry>
    {

        protected override void Invoke(Entry entry)
        {
            if(string.IsNullOrEmpty(entry.Text))
            {
                entry.BackgroundColor = Colors.Red;
            }
            else
            {
                entry.BackgroundColor = Colors.Transparent;
            }
        }

        public NotNullTrigger()
        {
        }
    }
}

