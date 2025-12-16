using System;

class Program
    {
        static void Main(string[] args)
        {
            // Khởi tạo đối tượng quản lý sinh viên
            StudentManager manager = new StudentManager();

            bool running = true;
            string input;
            int choice;

            while (running)
            {
                // In menu
                Console.WriteLine("\n========== MENU QUẢN LÝ SINH VIÊN ==========");
                Console.WriteLine("1. Thêm sinh viên");
                Console.WriteLine("2. Xóa sinh viên");
                Console.WriteLine("3. Cập nhật điểm");
                Console.WriteLine("4. In danh sách tất cả sinh viên");
                Console.WriteLine("5. Tính và hiển thị điểm trung bình");
                Console.WriteLine("6. Tìm và hiển thị điểm cao nhất");
                Console.WriteLine("7. Tìm sinh viên theo ID");
                Console.WriteLine("0. Thoát chương trình");
                Console.WriteLine("============================================");

                Console.Write("▶Nhập lựa chọn của bạn (0-7): ");
                input = Console.ReadLine();

                if (!int.TryParse(input, out choice))
                {
                    Console.WriteLine("Lựa chọn không hợp lệ. Vui lòng nhập một số nguyên.");
                    continue;
                }

                try
                {
                    switch (choice)
                    {
                        case 1: // Thêm sinh viên
                            Console.WriteLine("\n--- THÊM SINH VIÊN ---");
                            Console.Write("Nhập ID sinh viên: ");
                            string idAdd = Console.ReadLine();

                            Console.Write("Nhập Tên sinh viên: ");
                            string nameAdd = Console.ReadLine();

                            double scoreAdd;
                            Console.Write("Nhập Điểm (0-10): ");
                            if (!double.TryParse(Console.ReadLine(), out scoreAdd))
                            {
                                Console.WriteLine("Lỗi: Điểm nhập vào không phải là số hợp lệ.");
                                break;
                            }
                            Student student = new Student(idAdd, nameAdd, scoreAdd);
                            manager.AddStudent(student);
                            break;

                        case 2: // Xóa sinh viên
                            Console.WriteLine("\n--- XÓA SINH VIÊN ---");
                            Console.Write("Nhập ID sinh viên cần xóa: ");
                            string idRemove = Console.ReadLine();
                            manager.RemoveStudent(idRemove);
                            break;

                        case 3: // Cập nhật điểm
                            Console.WriteLine("\n--- CẬP NHẬT ĐIỂM ---");
                            Console.Write("Nhập ID sinh viên cần cập nhật: ");
                            string idUpdate = Console.ReadLine();

                            double newScore;
                            Console.Write("Nhập Điểm mới (0-10): ");
                            if (!double.TryParse(Console.ReadLine(), out newScore))
                            {
                                Console.WriteLine("Lỗi: Điểm mới nhập vào không phải là số hợp lệ.");
                                break; // Thoát khỏi case 3
                            }
                            manager.UpdateScore(idUpdate, newScore);
                            break;

                        case 4: // In danh sách
                            manager.DisplayAllStudents();
                            break;

                        case 5: // Tính điểm trung bình
                            double avgScore = manager.GetAverageScore();
                            Console.WriteLine($"\nĐiểm trung bình của tất cả sinh viên là: {avgScore:F2}");
                            break;

                        case 6: // Tìm điểm cao nhất
                            double maxScore = manager.GetMaxScore();
                            if (maxScore == -1.0)
                            {
                                Console.WriteLine("\nDanh sách sinh viên rỗng, không có điểm cao nhất.");
                            }
                            else
                            {
                                Console.WriteLine($"\n Điểm cao nhất hiện tại là: {maxScore}");
                            }
                            break;

                        case 7: // Tìm sinh viên theo ID
                            Console.WriteLine("\n--- TÌM SINH VIÊN ---");
                            Console.Write("Nhập ID sinh viên cần tìm: ");
                            string idFind = Console.ReadLine();
                            Student foundStudent = manager.FindStudentById(idFind);
                            if (foundStudent != null)
                            {
                                Console.WriteLine("Đã tìm thấy sinh viên:");
                                foundStudent.Display();
                            }
                            else
                            {
                                Console.WriteLine($"Không tìm thấy sinh viên có ID {idFind}.");
                            }
                            break;

                        case 0: // Thoát
                            running = false;
                            Console.WriteLine("\nChương trình kết thúc. Tạm biệt!");
                            break;

                        default:
                            Console.WriteLine("Lựa chọn không hợp lệ. Vui lòng chọn từ 0 đến 7.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"\nĐã xảy ra lỗi không mong muốn: {ex.Message}");
                    Console.WriteLine("Vui lòng thử lại.");
                }
            }
        }
    }