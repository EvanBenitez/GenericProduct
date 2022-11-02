using Microsoft.EntityFrameworkCore;

namespace API.Persistence
{
    public class StoredProcedures
    {
        public static async Task GenerateProcedures(GPContext context)
        {
            await spProducts_AdjustQuantity(context);
        }

        public static async Task spProducts_AdjustQuantity(GPContext context)
        {
            await context.Database
            .ExecuteSqlInterpolatedAsync(
                $@"Create Procedure spProducts_AdjustQuantity 
                    @id int,
                    @amount int
                as
                Begin

                    Declare @new_amount int;
                    Select @new_amount = Quantity from Products where Id = @id;
                    Select @new_amount = @new_amount + @amount;
                    IF @new_amount < 0
                        Select @new_amount = 0;
                    Update Products set Quantity = @new_amount
                        Where Id = @id;
                End");
        }
    }
}