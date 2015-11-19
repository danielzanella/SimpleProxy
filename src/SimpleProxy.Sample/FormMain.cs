using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;
using SimpleProxy.Example.Proxy;

namespace SimpleProxy.Example
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void Wrap(Action action)
        {
            try
            {
                action();
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Exception \"{0}\" caught:\r\n\r\n{1}\r\n\r\nStack trace:\r\n\r\n{2}", ex.GetType().Name, ex.Message, ex.StackTrace), "Houston, we have a problem");
            }
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            Thread.Sleep(2000);

            tbcMain_SelectedIndexChanged(tbcMain, EventArgs.Empty);
        }

        private void tbcMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tbcMain.SelectedIndex)
            {
                case 0:
                    Wrap(() => RestWebApiRefresh());
                    break;
                case 1:
                    Wrap(() => RestWebApi2Refresh());
                    break;
                case 2:
                    Wrap(() => RestWcfRefresh());
                    break;
                case 3:
                    Wrap(() => PageMethodsWebFormsRefresh());
                    break;
            }
        }

        #region REST WebApi

        private void RestWebApiRefresh()
        {
            ProxyConfiguration config = new ProxyConfiguration("http://localhost:59876/api");
            IFooRest fooSvc = SimpleProxy.Proxy.For<IFooRest>(config);

            IEnumerable<Foo> foos = fooSvc.FindAll();

            lstRestWebApi.Items.Clear();

            foreach (Foo foo in foos)
            {
                lstRestWebApi.Items.Add(foo.ToListViewItem());
            }
        }

        private void RestWebApiAdd()
        {
            string bar = BarDialog.ShowDialog(string.Empty);

            ProxyConfiguration config = new ProxyConfiguration("http://localhost:59876/api");
            IFooRest fooSvc = SimpleProxy.Proxy.For<IFooRest>(config);

            fooSvc.Add(new Foo { Bar = bar });

            RestWebApiRefresh();
        }

        private void RestWebApiUpdate()
        {
            if (lstRestWebApi.SelectedItems.Count != 1)
            {
                MessageBox.Show("Please select one item in the list.", "REST WebApi - Update");
                return;
            }

            int theId = 0;

            if (int.TryParse((string)lstRestWebApi.SelectedItems[0].Tag, out theId))
            {
                ProxyConfiguration config = new ProxyConfiguration("http://localhost:59876/api");
                IFooRest fooSvc = SimpleProxy.Proxy.For<IFooRest>(config);

                Foo foo = fooSvc.GetById(theId);

                string theBar = BarDialog.ShowDialog(foo.Bar);

                if (null != theBar)
                {
                    foo.Bar = theBar;

                    fooSvc.Update(foo.Id, foo);
                }
            }
            else
            {
                MessageBox.Show("Invalid Foo.", "REST WebApi - Update");

                lstRestWebApi.SelectedItems.Clear();
            }

            RestWebApiRefresh();
        }

        private void RestWebApiDelete()
        {
            if (lstRestWebApi.SelectedItems.Count != 1)
            {
                MessageBox.Show("Please select one item in the list.", "REST WebApi - Delete");
                return;
            }

            int theId = 0;

            if (int.TryParse((string)lstRestWebApi.SelectedItems[0].Tag, out theId))
            {
                ProxyConfiguration config = new ProxyConfiguration("http://localhost:59876/api");
                IFooRest fooSvc = SimpleProxy.Proxy.For<IFooRest>(config);

                fooSvc.Delete(theId);
            }
            else
            {
                MessageBox.Show("Invalid Foo.", "REST WebApi - Delete");

                lstRestWebApi.SelectedItems.Clear();
            }

            RestWebApiRefresh();
        }

        private void btnRestWebApiDelete_Click(object sender, EventArgs e)
        {
            Wrap(() => RestWebApiDelete());
        }

        private void btnRestWebApiEdit_Click(object sender, EventArgs e)
        {
            Wrap(() => RestWebApiUpdate());
        }

        private void btnRestWebApiAdd_Click(object sender, EventArgs e)
        {
            Wrap(() => RestWebApiAdd());
        }

        #endregion

        #region REST WebApi 2


        private void RestWebApi2Refresh()
        {
            ProxyConfiguration config = new ProxyConfiguration("http://localhost:59876/api");
            IFooRest fooSvc = SimpleProxy.Proxy.For<IFooRest2>(config);

            IEnumerable<Foo> foos = fooSvc.FindAll();

            lstRestWebApi2.Items.Clear();

            foreach (Foo foo in foos)
            {
                lstRestWebApi2.Items.Add(foo.ToListViewItem());
            }
        }

        private void RestWebApi2Add()
        {
            string bar = BarDialog.ShowDialog(string.Empty);

            ProxyConfiguration config = new ProxyConfiguration("http://localhost:59876/api");
            IFooRest fooSvc = SimpleProxy.Proxy.For<IFooRest2>(config);

            fooSvc.Add(new Foo { Bar = bar });

            RestWebApi2Refresh();
        }

        private void RestWebApi2Update()
        {
            if (lstRestWebApi2.SelectedItems.Count != 1)
            {
                MessageBox.Show("Please select one item in the list.", "REST WebApi 2 - Update");
                return;
            }

            int theId = 0;

            if (int.TryParse((string)lstRestWebApi2.SelectedItems[0].Tag, out theId))
            {
                ProxyConfiguration config = new ProxyConfiguration("http://localhost:59876/api");
                IFooRest fooSvc = SimpleProxy.Proxy.For<IFooRest2>(config);

                Foo foo = fooSvc.GetById(theId);

                string theBar = BarDialog.ShowDialog(foo.Bar);

                if (null != theBar)
                {
                    foo.Bar = theBar;

                    fooSvc.Update(foo.Id, foo);
                }
            }
            else
            {
                MessageBox.Show("Invalid Foo.", "REST WebApi 2 - Update");

                lstRestWebApi2.SelectedItems.Clear();
            }

            RestWebApi2Refresh();
        }

        private void RestWebApi2Delete()
        {
            if (lstRestWebApi2.SelectedItems.Count != 1)
            {
                MessageBox.Show("Please select one item in the list.", "REST WebApi 2 - Delete");
                return;
            }

            int theId = 0;

            if (int.TryParse((string)lstRestWebApi2.SelectedItems[0].Tag, out theId))
            {
                ProxyConfiguration config = new ProxyConfiguration("http://localhost:59876/api");
                IFooRest fooSvc = SimpleProxy.Proxy.For<IFooRest2>(config);

                fooSvc.Delete(theId);
            }
            else
            {
                MessageBox.Show("Invalid Foo.", "REST WebApi 2 - Delete");

                lstRestWebApi2.SelectedItems.Clear();
            }

            RestWebApi2Refresh();
        }

        private void btnRestWebApi2Add_Click(object sender, EventArgs e)
        {
            Wrap(() => RestWebApi2Add());
        }

        private void btnRestWebApi2Edit_Click(object sender, EventArgs e)
        {
            Wrap(() => RestWebApi2Update());
        }

        private void btnRestWebApi2Delete_Click(object sender, EventArgs e)
        {
            Wrap(() => RestWebApi2Delete());
        }

        #endregion

        #region REST Wcf

        private void RestWcfRefresh()
        {
            ProxyConfiguration config = new ProxyConfiguration("http://localhost:59877");
            IFooRestWcf fooSvc = SimpleProxy.Proxy.For<IFooRestWcf>(config);

            IEnumerable<Foo> foos = fooSvc.FindAll();

            lstRestWcf.Items.Clear();

            foreach (Foo foo in foos)
            {
                lstRestWcf.Items.Add(foo.ToListViewItem());
            }
        }

        private void RestWcfAdd()
        {
            string bar = BarDialog.ShowDialog(string.Empty);

            ProxyConfiguration config = new ProxyConfiguration("http://localhost:59877");
            IFooRestWcf fooSvc = SimpleProxy.Proxy.For<IFooRestWcf>(config);

            fooSvc.Add(new Foo { Bar = bar });

            RestWcfRefresh();
        }

        private void RestWcfUpdate()
        {
            if (lstRestWcf.SelectedItems.Count != 1)
            {
                MessageBox.Show("Please select one item in the list.", "REST Wcf - Update");
                return;
            }

            int theId = 0;

            if (int.TryParse((string)lstRestWcf.SelectedItems[0].Tag, out theId))
            {
                ProxyConfiguration config = new ProxyConfiguration("http://localhost:59877");
                IFooRestWcf fooSvc = SimpleProxy.Proxy.For<IFooRestWcf>(config);

                Foo foo = fooSvc.GetById(theId);

                string theBar = BarDialog.ShowDialog(foo.Bar);

                if (null != theBar)
                {
                    foo.Bar = theBar;

                    fooSvc.Update(foo.Id, foo);
                }
            }
            else
            {
                MessageBox.Show("Invalid Foo.", "REST Wcf - Update");

                lstRestWcf.SelectedItems.Clear();
            }

            RestWcfRefresh();
        }

        private void RestWcfDelete()
        {
            if (lstRestWcf.SelectedItems.Count != 1)
            {
                MessageBox.Show("Please select one item in the list.", "REST Wcf - Delete");
                return;
            }

            int theId = 0;

            if (int.TryParse((string)lstRestWcf.SelectedItems[0].Tag, out theId))
            {
                ProxyConfiguration config = new ProxyConfiguration("http://localhost:59877");
                IFooRestWcf fooSvc = SimpleProxy.Proxy.For<IFooRestWcf>(config);

                fooSvc.Delete(theId);
            }
            else
            {
                MessageBox.Show("Invalid Foo.", "REST Wcf - Delete");

                lstRestWcf.SelectedItems.Clear();
            }

            RestWcfRefresh();
        }

        private void btnRestWcfDelete_Click(object sender, EventArgs e)
        {
            Wrap(() => RestWcfDelete());
        }

        private void btnRestWcfEdit_Click(object sender, EventArgs e)
        {
            Wrap(() => RestWcfUpdate());
        }

        private void btnRestWcfAdd_Click(object sender, EventArgs e)
        {
            Wrap(() => RestWcfAdd());
        }

        #endregion

        #region PageMethods Web Forms

        private void PageMethodsWebFormsRefresh()
        {
            ProxyConfiguration config = new ProxyConfiguration("http://localhost:59878");
            IFooPageMethods fooSvc = SimpleProxy.Proxy.For<IFooPageMethods>(config);

            GetAllFoosResponse result = fooSvc.FindAll();

            IEnumerable<Foo> foos = result.D;

            lstPageMethodsWebForms.Items.Clear();

            foreach (Foo foo in foos)
            {
                lstPageMethodsWebForms.Items.Add(foo.ToListViewItem());
            }
        }

        private void PageMethodsWebFormsAdd()
        {
            string bar = BarDialog.ShowDialog(string.Empty);

            ProxyConfiguration config = new ProxyConfiguration("http://localhost:59878");
            IFooPageMethods fooSvc = SimpleProxy.Proxy.For<IFooPageMethods>(config);

            fooSvc.Add(new AddParameters { foo = new Foo { Bar = bar } });
            //fooSvc.Add(new Foo { Bar = bar });

            PageMethodsWebFormsRefresh();
        }

        private void PageMethodsWebFormsUpdate()
        {
            if (lstPageMethodsWebForms.SelectedItems.Count != 1)
            {
                MessageBox.Show("Please select one item in the list.", "PageMethods WebForms - Update");
                return;
            }

            int theId = 0;

            if (int.TryParse((string)lstPageMethodsWebForms.SelectedItems[0].Tag, out theId))
            {
                ProxyConfiguration config = new ProxyConfiguration("http://localhost:59878");
                IFooPageMethods fooSvc = SimpleProxy.Proxy.For<IFooPageMethods>(config);

                GetFooByIdResponse response = fooSvc.GetById(new FooByIdParameters { id = theId });
                Foo foo = response.D;

                string theBar = BarDialog.ShowDialog(foo.Bar);

                if (null != theBar)
                {
                    foo.Bar = theBar;

                    fooSvc.Update(new UpdateParameters { id = foo.Id, value = foo });
                }
            }
            else
            {
                MessageBox.Show("Invalid Foo.", "PageMethods WebForms - Update");

                lstPageMethodsWebForms.SelectedItems.Clear();
            }

            PageMethodsWebFormsRefresh();
        }

        private void PageMethodsWebFormsDelete()
        {
            if (lstPageMethodsWebForms.SelectedItems.Count != 1)
            {
                MessageBox.Show("Please select one item in the list.", "PageMethods WebForms - Delete");
                return;
            }

            int theId = 0;

            if (int.TryParse((string)lstPageMethodsWebForms.SelectedItems[0].Tag, out theId))
            {
                ProxyConfiguration config = new ProxyConfiguration("http://localhost:59878");
                IFooPageMethods fooSvc = SimpleProxy.Proxy.For<IFooPageMethods>(config);

                fooSvc.Delete(new FooByIdParameters { id = theId });
            }
            else
            {
                MessageBox.Show("Invalid Foo.", "PageMethods WebForms - Delete");

                lstPageMethodsWebForms.SelectedItems.Clear();
            }

            PageMethodsWebFormsRefresh();
        }

        private void btnPageMethodsWebFormsDelete_Click(object sender, EventArgs e)
        {
            Wrap(() => PageMethodsWebFormsDelete());
        }

        private void btnPageMethodsWebFormsEdit_Click(object sender, EventArgs e)
        {
            Wrap(() => PageMethodsWebFormsUpdate());
        }

        private void btnPageMethodsWebFormsAdd_Click(object sender, EventArgs e)
        {
            Wrap(() => PageMethodsWebFormsAdd());
        }

        #endregion

    }

    public static class FooExtensions
    {
        public static ListViewItem ToListViewItem(this Foo foo)
        {
            ListViewItem result = new ListViewItem();

            string theId = foo.Id.ToString(CultureInfo.InvariantCulture);

            result.Tag = theId;
            result.Text = theId;
            result.SubItems.Add(foo.Bar);

            return result;
        }
    }
}
