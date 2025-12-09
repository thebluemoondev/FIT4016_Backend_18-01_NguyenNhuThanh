using System;
using System.Text;
class Program
{
    static string XepLoai(double diem)
    {
        if(diem >= 8.5)
        {
            return "Giỏi";
        }else if(diem >= 7)
        {
            return "Khá";
        }else if(diem > 5.5)
        {
            return "Trung bình";
        }
        else
        {
            return "Yếu";
        }
    }

    static double TinhTrungBinh(double[] diem)
    {
        double tongDiem = 0;
        for(int i = 0; i < diem.Length; i++)
        {
            tongDiem += diem[i];
        }
        return tongDiem / diem.Length;
    }

    static void InBangDiem(string[] ten, double[] diem)
    {
        for(int i = 0; i < ten.Length; i++)
        {

        }
    }
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;

    }
}