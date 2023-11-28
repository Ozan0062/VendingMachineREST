namespace VendingMachineREST.Models
{
    public class AccountingsRepository
    {
        private readonly AccountingsDbContext? _context;

        public AccountingsRepository(AccountingsDbContext context)
        {
            _context = context;
        }

        public Accounting? Add(Accounting accounting)
        {
            accounting.Validate();
            _context?.Accounting.Add(accounting);
            _context?.SaveChanges();
            return accounting;
        }

        public IEnumerable<Accounting?> GetAll()
        {
            return _context?.Accounting;
        }
    }
}
