using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigurationDemo
{
    class MyConfigurationProvider : ConfigurationProvider
    {
        public override void Load()
        {
            LoadData();
        }

        private void LoadData(bool bReload = false)
        {
            this.Data["TestTime"] = DateTime.Now.ToString();

            if (bReload)
                base.OnReload();
        }
    }
}
