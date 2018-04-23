using System.ComponentModel;
using System.Windows;
using DevExpress.DataAccess.ObjectBinding;
using DevExpress.Xpf.Reports.UserDesigner;
using DevExpress.XtraReports.UI;

namespace WpfApplication1 {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            designer.OpenDocument(new XtraReport1());
        }

        void ReplaceDataSource_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            var newDataSource = new ObjectDataSource { DataSource = typeof(MyDataClass) };
            XtraReport report = designer.ActiveDocument.Diagram.RootItem.XRObject;
            var oldDataSource = report.DataSource as IComponent;

            designer.ActiveDocument.MakeChanges(changes => {
                if(oldDataSource != null) {
                    changes.RemoveItem(oldDataSource);
                }
                changes.AddItem(newDataSource);
                changes.SetProperty(report, x => x.DataSource, newDataSource);
            });
        }
    }
}
