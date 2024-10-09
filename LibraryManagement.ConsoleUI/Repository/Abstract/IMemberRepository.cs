using LibraryManagement.ConsoleUI.Models;

namespace LibraryManagement.ConsoleUI.Repository.Abstract;

public interface IMemberRepository : IRepository<Member, string>
{
  public Member? Update(Member member);
}
