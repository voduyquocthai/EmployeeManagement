namespace EmployeeManagement.Repositories
{
    public interface IIdGenerator
    {
        int GenId();
    }

    public class IdGenerator : IIdGenerator
    {
        private static int _current = 0;

        public int GenId()
        {


            return _current++;
        }
    }
}