using LibraryManagement.ConsoleUI.Models;
using LibraryManagement.ConsoleUI.Repository.Abstract;

namespace LibraryManagement.ConsoleUI.Repository.Concrete;

public class MemberRepository : BaseRepository, IMemberRepository
{
  private List<Member> members;

  public MemberRepository()
  {
    members = Members();
  }

  public List<Member> GetAll()
  {
    return members;
  }

  public Member? GetById(string id)
  {
    Member? member = members.FirstOrDefault(m => m.Id == id);
    return member;
  }

  public Member Add(Member member)
  {
    members.Add(member);
    return member;
  }

  public Member? Remove(string id)
  {
    Member? removedMember = GetById(id);

    if (removedMember != null)
    {
      members.Remove(removedMember);
      return removedMember;
    }
    return null;
  }

  public Member? Update(Member updatedMember)
  {
    Member? existingMember = GetById(updatedMember.Id);

    if (existingMember != null)
    {
      int index = members.IndexOf(existingMember);
      members.Remove(existingMember);
      members.Insert(index, updatedMember);
      return updatedMember;
    }
    return null;
  }
}
