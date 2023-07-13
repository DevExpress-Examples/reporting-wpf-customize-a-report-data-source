Imports System.ComponentModel
Imports System.Windows
Imports DevExpress.DataAccess.ObjectBinding
Imports DevExpress.Xpf.Reports.UserDesigner
Imports DevExpress.XtraReports.UI

Namespace WpfApplication1

    ''' <summary>
    ''' Interaction logic for MainWindow.xaml
    ''' </summary>
    Partial Public Class MainWindow
        Inherits Window

        Public Sub New()
            Me.InitializeComponent()
            Me.designer.OpenDocument(New XtraReport1())
        End Sub

        Private Sub ReplaceDataSource_ItemClick(ByVal sender As Object, ByVal e As DevExpress.Xpf.Bars.ItemClickEventArgs)
            Dim newDataSource = New ObjectDataSource With {.DataSource = GetType(MyDataClass)}
            Dim report As XtraReport = Me.designer.ActiveDocument.Diagram.RootItem.XRObject
            Dim oldDataSource = TryCast(report.DataSource, IComponent)
            Me.designer.ActiveDocument.MakeChanges(Sub(changes)
                                                       If oldDataSource IsNot Nothing Then
                                                           changes.RemoveItem(oldDataSource)
                                                       End If

                                                       changes.AddItem(newDataSource)
                                                       changes.SetProperty(report, Function(x) x.DataSource, newDataSource)
                                                   End Sub)
        End Sub
    End Class
End Namespace
