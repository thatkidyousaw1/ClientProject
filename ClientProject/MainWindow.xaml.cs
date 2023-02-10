using ClientProject.DatabaseService;
using ClientProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ClientProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public List<UserData> DatabaseUsers { get; private set; }

        public void Create()
        {
            using (InputDataContext context = new InputDataContext())
            {
                var client = ClientName.Text;
                var department = DepartmentName.Text;
                var purchaseOrder = PurchaseOrder.Text;
                var tinNo = TinNumber.Text;
                var address = Address.Text;
                var type = TypeName.Text;
                var quantity = Quantity.Text;
                var items = Items.Text;
                var unitPrice = UnitPrice.Text;
                var amount = Amount.Text;
                var checkAmount = CheckAmount.Text;
                var withTax = WithholdingTax.Text;
                var officeReceiptNo = ReceiptNumber.Text;
                var datePaid = DatePaid.Text;
                var bir2307 = Bir2307.Text;
                var bir2306 = Bir2306.Text;

                if (client != null && department != null && purchaseOrder != null && tinNo != null
                    && address != null && type != null && quantity != null && items != null && unitPrice != null && 
                    amount != null && checkAmount != null && withTax != null &&  officeReceiptNo != null && 
                    datePaid != null && bir2307 != null && bir2306 != null)
                {
                    context.UserData.Add(new UserData()
                    {
                        ClientName = client,
                        Department = department,
                        PurchaseOrder = purchaseOrder,
                        TinNumber = tinNo,
                        Address = address,
                        Type = type,
                        Quantity = quantity,
                        Items = items,
                        UnitPrice = unitPrice,
                        Amount = amount,
                        CheckAmount = checkAmount,
                        WithTax = withTax,
                        OfficeReceiptNumber = officeReceiptNo,
                        DatePaid = datePaid,
                        Bir2306 = bir2306,
                        Bir2307 = bir2307,
                    });

                    context.SaveChanges();
                }
            }
        }

        public void Update()
        {
            using (InputDataContext context = new InputDataContext())
            {
                DatabaseUsers = context.UserData.ToList();
                ProductListView.ItemsSource = DatabaseUsers;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Create();
            Update();
        }
    }
}
