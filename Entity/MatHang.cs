namespace DoAnMonHoc_23880108.Entity
{
	public class MatHang
	{
		public string Ma { get; set; }
		public string Ten { get; set; }
		public string Loai { get; set; }
		public string CongTySX { get; set; }
		public DateOnly NSX { get; set; }
		public DateOnly HSD { get; set; }
		public int Gia { get; set; }

		public MatHang(string ma, string ten, string loai, string cty, string nsx, string hsd, int gia)
		{	
			Ma = ma;
			Ten = ten;
			Loai = loai;
			CongTySX = cty;
			NSX = DateOnly.Parse(nsx);
			HSD = DateOnly.Parse(hsd);
			Gia = gia;
		}		
	}
}
