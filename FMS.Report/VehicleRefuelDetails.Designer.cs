namespace FMS.Report
{
    partial class VehicleRefuelDetails
    {
        #region Component Designer generated code
        /// <summary>
        /// Required method for telerik Reporting designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Telerik.Reporting.ReportParameter reportParameter1 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.Drawing.StyleRule styleRule1 = new Telerik.Reporting.Drawing.StyleRule();
            this.Area3 = new Telerik.Reporting.DetailSection();
            this.RegistrationNumber1 = new Telerik.Reporting.TextBox();
            this.VehicleDescription1 = new Telerik.Reporting.TextBox();
            this.Condition1 = new Telerik.Reporting.TextBox();
            this.StaffNumber1 = new Telerik.Reporting.TextBox();
            this.sqldsVehicleActivitiesHistoryRefuel = new Telerik.Reporting.SqlDataSource();
            this.reportHeaderSection1 = new Telerik.Reporting.ReportHeaderSection();
            this.textBox1 = new Telerik.Reporting.TextBox();
            this.Text2 = new Telerik.Reporting.TextBox();
            this.Text12 = new Telerik.Reporting.TextBox();
            this.Text13 = new Telerik.Reporting.TextBox();
            this.Text3 = new Telerik.Reporting.TextBox();
            this.Area4 = new Telerik.Reporting.ReportFooterSection();
            this.textBox2 = new Telerik.Reporting.TextBox();
            this.textBox3 = new Telerik.Reporting.TextBox();
            this.textBox4 = new Telerik.Reporting.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Area3
            // 
            this.Area3.CanShrink = true;
            this.Area3.Height = Telerik.Reporting.Drawing.Unit.Inch(0.25D);
            this.Area3.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.RegistrationNumber1,
            this.VehicleDescription1,
            this.Condition1,
            this.StaffNumber1});
            this.Area3.KeepTogether = false;
            this.Area3.Name = "Area3";
            this.Area3.PageBreak = Telerik.Reporting.PageBreak.None;
            this.Area3.Style.BackgroundColor = System.Drawing.Color.White;
            this.Area3.Style.Visible = true;
            // 
            // RegistrationNumber1
            // 
            this.RegistrationNumber1.CanGrow = true;
            this.RegistrationNumber1.CanShrink = false;
            this.RegistrationNumber1.Format = "{0:d}";
            this.RegistrationNumber1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.283D), Telerik.Reporting.Drawing.Unit.Inch(0.031D));
            this.RegistrationNumber1.Name = "RegistrationNumber1";
            this.RegistrationNumber1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.817D), Telerik.Reporting.Drawing.Unit.Inch(0.16D));
            this.RegistrationNumber1.Style.BackgroundColor = System.Drawing.Color.White;
            this.RegistrationNumber1.Style.BorderColor.Default = System.Drawing.Color.Black;
            this.RegistrationNumber1.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.RegistrationNumber1.Style.Color = System.Drawing.Color.Black;
            this.RegistrationNumber1.Style.Font.Bold = false;
            this.RegistrationNumber1.Style.Font.Italic = false;
            this.RegistrationNumber1.Style.Font.Name = "Arial";
            this.RegistrationNumber1.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.RegistrationNumber1.Style.Font.Strikeout = false;
            this.RegistrationNumber1.Style.Font.Underline = false;
            this.RegistrationNumber1.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.RegistrationNumber1.Style.Visible = true;
            this.RegistrationNumber1.Value = "= Fields.Date";
            // 
            // VehicleDescription1
            // 
            this.VehicleDescription1.CanGrow = true;
            this.VehicleDescription1.CanShrink = false;
            this.VehicleDescription1.Format = "{0:N2}";
            this.VehicleDescription1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(4.7D), Telerik.Reporting.Drawing.Unit.Inch(0.031D));
            this.VehicleDescription1.Name = "VehicleDescription1";
            this.VehicleDescription1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.013D), Telerik.Reporting.Drawing.Unit.Inch(0.16D));
            this.VehicleDescription1.Style.BackgroundColor = System.Drawing.Color.White;
            this.VehicleDescription1.Style.BorderColor.Default = System.Drawing.Color.Black;
            this.VehicleDescription1.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.VehicleDescription1.Style.Color = System.Drawing.Color.Black;
            this.VehicleDescription1.Style.Font.Bold = false;
            this.VehicleDescription1.Style.Font.Italic = false;
            this.VehicleDescription1.Style.Font.Name = "Arial";
            this.VehicleDescription1.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.VehicleDescription1.Style.Font.Strikeout = false;
            this.VehicleDescription1.Style.Font.Underline = false;
            this.VehicleDescription1.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.VehicleDescription1.Style.Visible = true;
            this.VehicleDescription1.Value = "= Fields.Liters";
            // 
            // Condition1
            // 
            this.Condition1.CanGrow = true;
            this.Condition1.CanShrink = false;
            this.Condition1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(2D), Telerik.Reporting.Drawing.Unit.Inch(0.031D));
            this.Condition1.Name = "Condition1";
            this.Condition1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.505D), Telerik.Reporting.Drawing.Unit.Inch(0.16D));
            this.Condition1.Style.BackgroundColor = System.Drawing.Color.White;
            this.Condition1.Style.BorderColor.Default = System.Drawing.Color.Black;
            this.Condition1.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.Condition1.Style.Color = System.Drawing.Color.Black;
            this.Condition1.Style.Font.Bold = false;
            this.Condition1.Style.Font.Italic = false;
            this.Condition1.Style.Font.Name = "Arial";
            this.Condition1.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.Condition1.Style.Font.Strikeout = false;
            this.Condition1.Style.Font.Underline = false;
            this.Condition1.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.Condition1.Style.Visible = true;
            this.Condition1.Value = "= Fields.FuelType";
            // 
            // StaffNumber1
            // 
            this.StaffNumber1.CanGrow = true;
            this.StaffNumber1.CanShrink = false;
            this.StaffNumber1.Format = "{0:C2}";
            this.StaffNumber1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(6.3D), Telerik.Reporting.Drawing.Unit.Inch(0.031D));
            this.StaffNumber1.Name = "StaffNumber1";
            this.StaffNumber1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.271D), Telerik.Reporting.Drawing.Unit.Inch(0.16D));
            this.StaffNumber1.Style.BackgroundColor = System.Drawing.Color.White;
            this.StaffNumber1.Style.BorderColor.Default = System.Drawing.Color.Black;
            this.StaffNumber1.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.StaffNumber1.Style.Color = System.Drawing.Color.Black;
            this.StaffNumber1.Style.Font.Bold = false;
            this.StaffNumber1.Style.Font.Italic = false;
            this.StaffNumber1.Style.Font.Name = "Arial";
            this.StaffNumber1.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.StaffNumber1.Style.Font.Strikeout = false;
            this.StaffNumber1.Style.Font.Underline = false;
            this.StaffNumber1.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.StaffNumber1.Style.Visible = true;
            this.StaffNumber1.Value = "= Fields.TotalCost";
            // 
            // sqldsVehicleActivitiesHistoryRefuel
            // 
            this.sqldsVehicleActivitiesHistoryRefuel.ConnectionString = "FMSEntities";
            this.sqldsVehicleActivitiesHistoryRefuel.Name = "sqldsVehicleActivitiesHistoryRefuel";
            this.sqldsVehicleActivitiesHistoryRefuel.SelectCommand = " SELECT * \r\n FROM   \"VehicleActivitiesHistoryFuel\" \"VehicleActivitiesHistoryFuel\"" +
    "\r\n\r\n\r\n";
            // 
            // reportHeaderSection1
            // 
            this.reportHeaderSection1.CanShrink = true;
            this.reportHeaderSection1.Height = Telerik.Reporting.Drawing.Unit.Inch(0.56D);
            this.reportHeaderSection1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBox1,
            this.Text2,
            this.Text12,
            this.Text13,
            this.Text3});
            this.reportHeaderSection1.Name = "reportHeaderSection1";
            // 
            // textBox1
            // 
            this.textBox1.CanGrow = false;
            this.textBox1.CanShrink = false;
            this.textBox1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.283D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.554D), Telerik.Reporting.Drawing.Unit.Inch(0.26D));
            this.textBox1.Style.BackgroundColor = System.Drawing.Color.Transparent;
            this.textBox1.Style.BorderColor.Default = System.Drawing.Color.Black;
            this.textBox1.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox1.Style.Color = System.Drawing.Color.Black;
            this.textBox1.Style.Font.Bold = false;
            this.textBox1.Style.Font.Italic = false;
            this.textBox1.Style.Font.Name = "Arial";
            this.textBox1.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(16D);
            this.textBox1.Style.Font.Strikeout = false;
            this.textBox1.Style.Font.Underline = false;
            this.textBox1.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.textBox1.Style.Visible = true;
            this.textBox1.Value = "Refuel Details";
            // 
            // Text2
            // 
            this.Text2.CanGrow = false;
            this.Text2.CanShrink = false;
            this.Text2.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.3D), Telerik.Reporting.Drawing.Unit.Inch(0.4D));
            this.Text2.Name = "Text2";
            this.Text2.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.8D), Telerik.Reporting.Drawing.Unit.Inch(0.16D));
            this.Text2.Style.BackgroundColor = System.Drawing.Color.Transparent;
            this.Text2.Style.BorderColor.Default = System.Drawing.Color.Black;
            this.Text2.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.Text2.Style.Color = System.Drawing.Color.Black;
            this.Text2.Style.Font.Bold = true;
            this.Text2.Style.Font.Italic = false;
            this.Text2.Style.Font.Name = "Arial";
            this.Text2.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.Text2.Style.Font.Strikeout = false;
            this.Text2.Style.Font.Underline = false;
            this.Text2.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.Text2.Style.Visible = true;
            this.Text2.Value = "Date";
            // 
            // Text12
            // 
            this.Text12.CanGrow = false;
            this.Text12.CanShrink = false;
            this.Text12.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(2D), Telerik.Reporting.Drawing.Unit.Inch(0.4D));
            this.Text12.Name = "Text12";
            this.Text12.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.505D), Telerik.Reporting.Drawing.Unit.Inch(0.16D));
            this.Text12.Style.BackgroundColor = System.Drawing.Color.Transparent;
            this.Text12.Style.BorderColor.Default = System.Drawing.Color.Black;
            this.Text12.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.Text12.Style.Color = System.Drawing.Color.Black;
            this.Text12.Style.Font.Bold = true;
            this.Text12.Style.Font.Italic = false;
            this.Text12.Style.Font.Name = "Arial";
            this.Text12.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.Text12.Style.Font.Strikeout = false;
            this.Text12.Style.Font.Underline = false;
            this.Text12.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.Text12.Style.Visible = true;
            this.Text12.Value = "Fuel Type";
            // 
            // Text13
            // 
            this.Text13.CanGrow = false;
            this.Text13.CanShrink = false;
            this.Text13.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(4.7D), Telerik.Reporting.Drawing.Unit.Inch(0.4D));
            this.Text13.Name = "Text13";
            this.Text13.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.013D), Telerik.Reporting.Drawing.Unit.Inch(0.16D));
            this.Text13.Style.BackgroundColor = System.Drawing.Color.Transparent;
            this.Text13.Style.BorderColor.Default = System.Drawing.Color.Black;
            this.Text13.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.Text13.Style.Color = System.Drawing.Color.Black;
            this.Text13.Style.Font.Bold = true;
            this.Text13.Style.Font.Italic = false;
            this.Text13.Style.Font.Name = "Arial";
            this.Text13.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.Text13.Style.Font.Strikeout = false;
            this.Text13.Style.Font.Underline = false;
            this.Text13.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.Text13.Style.Visible = true;
            this.Text13.Value = "Litres";
            // 
            // Text3
            // 
            this.Text3.CanGrow = false;
            this.Text3.CanShrink = false;
            this.Text3.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(6.3D), Telerik.Reporting.Drawing.Unit.Inch(0.4D));
            this.Text3.Name = "Text3";
            this.Text3.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.271D), Telerik.Reporting.Drawing.Unit.Inch(0.16D));
            this.Text3.Style.BackgroundColor = System.Drawing.Color.Transparent;
            this.Text3.Style.BorderColor.Default = System.Drawing.Color.Black;
            this.Text3.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.Text3.Style.Color = System.Drawing.Color.Black;
            this.Text3.Style.Font.Bold = true;
            this.Text3.Style.Font.Italic = false;
            this.Text3.Style.Font.Name = "Arial";
            this.Text3.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.Text3.Style.Font.Strikeout = false;
            this.Text3.Style.Font.Underline = false;
            this.Text3.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.Text3.Style.Visible = true;
            this.Text3.Value = "Cost";
            // 
            // Area4
            // 
            this.Area4.CanShrink = true;
            this.Area4.Height = Telerik.Reporting.Drawing.Unit.Inch(0.35D);
            this.Area4.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBox2,
            this.textBox3,
            this.textBox4});
            this.Area4.KeepTogether = false;
            this.Area4.Name = "Area4";
            this.Area4.PageBreak = Telerik.Reporting.PageBreak.None;
            this.Area4.Style.BackgroundColor = System.Drawing.Color.Transparent;
            this.Area4.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.None;
            this.Area4.Style.BorderWidth.Bottom = Telerik.Reporting.Drawing.Unit.Point(1D);
            this.Area4.Style.LineWidth = Telerik.Reporting.Drawing.Unit.Point(1D);
            this.Area4.Style.Visible = true;
            // 
            // textBox2
            // 
            this.textBox2.CanGrow = false;
            this.textBox2.CanShrink = false;
            this.textBox2.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(3.7D), Telerik.Reporting.Drawing.Unit.Inch(0.08D));
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.942D), Telerik.Reporting.Drawing.Unit.Inch(0.16D));
            this.textBox2.Style.BackgroundColor = System.Drawing.Color.Transparent;
            this.textBox2.Style.BorderColor.Default = System.Drawing.Color.Black;
            this.textBox2.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox2.Style.Color = System.Drawing.Color.Black;
            this.textBox2.Style.Font.Bold = true;
            this.textBox2.Style.Font.Italic = false;
            this.textBox2.Style.Font.Name = "Arial";
            this.textBox2.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.textBox2.Style.Font.Strikeout = false;
            this.textBox2.Style.Font.Underline = false;
            this.textBox2.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.textBox2.Style.Visible = true;
            this.textBox2.Value = "Refuel Total:";
            // 
            // textBox3
            // 
            this.textBox3.CanGrow = true;
            this.textBox3.CanShrink = false;
            this.textBox3.Format = "{0:N2}";
            this.textBox3.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(4.7D), Telerik.Reporting.Drawing.Unit.Inch(0.08D));
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.013D), Telerik.Reporting.Drawing.Unit.Inch(0.16D));
            this.textBox3.Style.BackgroundColor = System.Drawing.Color.Transparent;
            this.textBox3.Style.BorderColor.Default = System.Drawing.Color.Black;
            this.textBox3.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox3.Style.Color = System.Drawing.Color.Black;
            this.textBox3.Style.Font.Bold = true;
            this.textBox3.Style.Font.Italic = false;
            this.textBox3.Style.Font.Name = "Arial";
            this.textBox3.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.textBox3.Style.Font.Strikeout = false;
            this.textBox3.Style.Font.Underline = false;
            this.textBox3.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.textBox3.Style.Visible = true;
            this.textBox3.Value = "= Sum(Fields.Liters)";
            // 
            // textBox4
            // 
            this.textBox4.CanGrow = true;
            this.textBox4.CanShrink = false;
            this.textBox4.Format = "{0:C2}";
            this.textBox4.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(6.3D), Telerik.Reporting.Drawing.Unit.Inch(0.08D));
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.271D), Telerik.Reporting.Drawing.Unit.Inch(0.16D));
            this.textBox4.Style.BackgroundColor = System.Drawing.Color.Transparent;
            this.textBox4.Style.BorderColor.Default = System.Drawing.Color.Black;
            this.textBox4.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox4.Style.Color = System.Drawing.Color.Black;
            this.textBox4.Style.Font.Bold = true;
            this.textBox4.Style.Font.Italic = false;
            this.textBox4.Style.Font.Name = "Arial";
            this.textBox4.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.textBox4.Style.Font.Strikeout = false;
            this.textBox4.Style.Font.Underline = false;
            this.textBox4.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.textBox4.Style.Visible = true;
            this.textBox4.Value = "= Sum(Fields.TotalCost)";
            // 
            // VehicleRefuelDetails
            // 
            this.DataSource = this.sqldsVehicleActivitiesHistoryRefuel;
            this.Filters.Add(new Telerik.Reporting.Filter("= Fields.RegistrationNumber", Telerik.Reporting.FilterOperator.Equal, "= Parameters.paramRegistrationNumber.Value"));
            this.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.Area3,
            this.Area4,
            this.reportHeaderSection1});
            this.Name = "AllocatedVehiclesReport";
            this.PageSettings.ContinuousPaper = false;
            this.PageSettings.Landscape = false;
            this.PageSettings.Margins = new Telerik.Reporting.Drawing.MarginsU(Telerik.Reporting.Drawing.Unit.Mm(0.25D), Telerik.Reporting.Drawing.Unit.Mm(0.25D), Telerik.Reporting.Drawing.Unit.Mm(0.25D), Telerik.Reporting.Drawing.Unit.Mm(0.25D));
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4;
            reportParameter1.Name = "paramRegistrationNumber";
            this.ReportParameters.Add(reportParameter1);
            this.Style.BackgroundColor = System.Drawing.Color.Transparent;
            this.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.Style.LineWidth = Telerik.Reporting.Drawing.Unit.Point(3D);
            styleRule1.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.TypeSelector(typeof(Telerik.Reporting.TextItemBase)),
            new Telerik.Reporting.Drawing.TypeSelector(typeof(Telerik.Reporting.HtmlTextBox))});
            styleRule1.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Point(2D);
            styleRule1.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Point(2D);
            this.StyleSheet.AddRange(new Telerik.Reporting.Drawing.StyleRule[] {
            styleRule1});
            this.Width = Telerik.Reporting.Drawing.Unit.Mm(198.12D);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion
        private Telerik.Reporting.DetailSection Area3;
        private Telerik.Reporting.SqlDataSource sqldsVehicleActivitiesHistoryRefuel;
        private Telerik.Reporting.ReportHeaderSection reportHeaderSection1;
        private Telerik.Reporting.TextBox RegistrationNumber1;
        private Telerik.Reporting.TextBox VehicleDescription1;
        private Telerik.Reporting.TextBox Condition1;
        private Telerik.Reporting.TextBox StaffNumber1;
        private Telerik.Reporting.TextBox textBox1;
        private Telerik.Reporting.TextBox Text2;
        private Telerik.Reporting.TextBox Text12;
        private Telerik.Reporting.TextBox Text13;
        private Telerik.Reporting.TextBox Text3;
        private Telerik.Reporting.ReportFooterSection Area4;
        private Telerik.Reporting.TextBox textBox2;
        private Telerik.Reporting.TextBox textBox3;
        private Telerik.Reporting.TextBox textBox4;
    }
}