namespace Web.Middleware
{
    public class MyMiddleware
    {
        private readonly RequestDelegate _next; 
        
        public MyMiddleware(RequestDelegate next) 
        {
            _next = next;
        }
        
        public async Task InvokeAsync(HttpContext context) 
        {
            if (context.Request.Query["username"] == "user1" && context.Request.Query["password"] == "password1") {
                context.Request.HttpContext.Items.Add("userdetails", "blallf");
                await _next(context);
            } 
            else 
            {
                await context.Response.WriteAsync("Not Authorized!");
            }
        }
    }
}