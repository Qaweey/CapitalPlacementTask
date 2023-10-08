namespace CapitalPlacementTask.Dtos
{
    public class BaseResponse
    {
        public string Code { get; set; }

        public string Message { get; set; }

        public string? Id { get; set; }
        public object Data { get; set; }


    }
}
