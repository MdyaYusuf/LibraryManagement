using LibraryManagement.ConsoleUI.Models;
using LibraryManagement.ConsoleUI.Repository.Concrete;

namespace LibraryManagement.ConsoleUI.Service;

public class MemberService
{
  MemberRepository memberRepository = new MemberRepository();

  public void GetAllMembers()
  {
    List<Member> members = memberRepository.GetAll();

    foreach (Member member in members)
    {
      Console.WriteLine(member);
    }
  }

  public void GetById(string id)
  {
    Member? member = memberRepository.GetById(id);

    if (member == null)
    {
      Console.WriteLine($"{id} numaralı üye mevcut değil.");
    }
    else
    {
      Console.WriteLine(member);
    }
  }

  public void Add(Member member)
  {
    Member? createdMember = memberRepository.Add(member);
    Console.WriteLine("Üye eklendi.");
    Console.WriteLine(createdMember);
  }

  public void Remove(string id)
  {
    Member? removedMember = memberRepository.Remove(id);

    if (removedMember == null)
    {
      Console.WriteLine("Üye silinemedi çünkü zaten yok.");
      return;
    }
    else
    {
      Console.WriteLine("Üye silindi.");
      Console.WriteLine(removedMember);
    }
  }

  public void Update(Member member)
  {
    Member? updatedMember = memberRepository.Update(member);
    if (updatedMember == null)
    {
      Console.WriteLine($"Update işlemini gerçekleştiremedik çünkü girmiş olduğunuz {member.Id} ile eşleşen bir üye kaydı mevcut değil.");
    }
    else
    {
      Console.WriteLine($"{member.Id} numaralı üye güncellendi.");
      Console.WriteLine(updatedMember);
    }
  }
}
