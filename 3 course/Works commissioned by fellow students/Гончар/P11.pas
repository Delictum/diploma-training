program cal;//11ЛАБА - Создать программу, содержащую сведения о месячной заработной плате работников предприятия. 
//Каждая запись содержит поля - фамилия работника, наименование отдела, размер заработной платы за месяц. 
//Вывести работников по отделам в порядке возрастания их зарплат
type
  PList = ^TList;
  TList = record
    author: string[20];
    name: string[20];
    year: integer;
    pages: integer;
    next: PList;   
  end;

procedure addAb(var head: plist; author: string[20]; name: string[20]; year: integer; pages: integer);
var
  cur: plist;
begin
  new(cur);
  cur^.next := head; 
  cur^.author := author; 
  cur^.name := name; 
  cur^.year := year;
  cur^.pages := pages;
  head := cur;
end;

var
  i, j, n, l, k: integer;
  author, name: string[20];
  year, pages, m, m_prev: integer;
  head, f, f1: PList; 
  deps: array of integer;
  s: integer;


begin
  write('Сколько книг в списке? ');
  readln(n);
  for i := 1 to n do
  begin
    write('Введите автора: ');
    readln(author);
    write('Введите название: ');
    readln(name);
    write('Введите год издания: ');
    readln(year);
    write('Введите количество страниц: ');
    readln(pages);
    addAb(head, author, name, year, pages);
  end;
  SetLength(deps, n + 1);
  f := head;
  writeln;
  for i := 1 to n do
  begin
    writeln(f^.author, ' ', f^.name, ' ', f^.year, ' ', f^.pages);
    f := f^.next;
  end;
  
  l := 0; 
  f := head;  
  for i := 1 to n do 
  begin
    deps[i] := f^.year;    
    f := f^.next;
  end;
  writeln;
  
  for i := 1 to n do
    for j := n downto i do
      if (deps[i] <= deps[j]) then
      begin
        s := deps[i];
        deps[i] := deps[j];
        deps[j] := s;
      end;
  
  
  for i := 1 to n do  
  begin
  f := head; 
    for j := 1 to n do 
    begin
      if (f^.year = deps[i]) then
        writeln(f^.author, ' ', f^.name, ' ', f^.year, ' ', f^.pages);
      f := f^.next;
    end;
    end;
end.