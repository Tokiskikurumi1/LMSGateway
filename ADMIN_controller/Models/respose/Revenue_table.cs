namespace ADMIN_controller.Models.respose
{
  
        public class Revenue_table
        {
            public int RevenueID { get; set; }
            public string StudentName { get; set; }
            public string CourseName { get; set; }
            public decimal Amount { get; set; }
            public string PaymentMethod { get; set; } // Chuyển khoản, Tiền mặt, Momo...
            public DateTime PaymentDate { get; set; }
            public string Status { get; set; } // Đã thanh toán, Chưa thanh toán, Chờ xác nhận
        }

}
