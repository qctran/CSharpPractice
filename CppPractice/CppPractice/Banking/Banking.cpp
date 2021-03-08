// Banking.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>

using namespace std;

class Account
{
private:
  float balance;

public:
  Account();
  void Deposit(float amount);
  float GetBalance();

};

Account::Account()
{
  balance = 0;
}
void Account::Deposit(float amount)
{
  balance += amount;
}
float Account::GetBalance()
{
  return balance;
}

void PrintOutput(Account, string);
int main()
{
  Account checking;
  Account saving;

  PrintOutput(checking, "Checking");
  PrintOutput(saving, "Saving");

  checking.Deposit(1.25);
  saving.Deposit(300.20);

  cout << "Checking balance: " << checking.GetBalance() << endl;
  cout << "Saving balance: " << saving.GetBalance() << endl;
}

void PrintOutput(Account account, string accountType)
{
  cout << accountType << " balance: " << account.GetBalance() << endl;
}

void PointerDemo()
{
  int v1 = 100;
  int* p1;
  p1 = &v1;
  *p1 = 35;
  cout << "p1: " << p1 << " and v1: " << v1 << endl;
}

