namespace hotel_clientes.DTO
{
    public class ApiResponse
    {
        public ApiResponse(bool success,string message,object data,object errors) {
            this.success = success;
            this.message = message;
            this.data = data;
            this.errors = errors;
        }
        public bool success { get; set; }
        public string message { get; set; }
        public object data { get; set; }
        public object errors { get; set; }
    }
}
