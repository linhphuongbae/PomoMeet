using Google.Cloud.Firestore;
using PomoMeetApp.Classes;

public class UserStatusManager
{
    private static UserStatusManager _instance;
    private FirestoreDb _db;

    // Constructor riêng để đảm bảo không thể khởi tạo bên ngoài
    private UserStatusManager()
    {
        _db = FirebaseConfig.database;
    }

    // Thuộc tính công khai để truy cập đối tượng Singleton
    public static UserStatusManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new UserStatusManager();
            }
            return _instance;
        }
    }

    // Cập nhật trạng thái người dùng
    public async Task UpdateUserStatus(string userId, string status)
    {
        try
        {
            var userRef = _db.Collection("User").Document(userId);
            await userRef.UpdateAsync(new Dictionary<string, object>
            {
                { "status", status }
            });
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error updating user status: {ex.Message}");
        }
    }
}
