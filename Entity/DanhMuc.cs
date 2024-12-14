namespace DoAnMonHoc_23880108.Entity
{
	public class DanhMuc
	{
		public string MaHoaDon {  get; set; }
		public string TenHang { get; set; }
		public string DonVi {  get; set; }
		public int SoLuong { get; set; }
		public int DonGia { get; set; }

		public DanhMuc(string maHD, string ten, string donVi, int soLuong, int donGia)
		{
			MaHoaDon = maHD;
			TenHang = ten;
			DonVi = donVi;
			SoLuong = soLuong;
			DonGia = donGia;
		}
	}
}
