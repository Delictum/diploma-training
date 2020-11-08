program spisok;

type
  name = string[10];
  ukaz = ^element;
  element = record
    uk: ukaz;
    dan: name
  end;

var
  kniga: name;
  nach, tek, ob, obpr: ukaz;
  i: integer;

begin{ формирование 1-го элемента списка }
  New(nach);
  ReadLn;
  WriteLn('введите первое название');
  Read(kniga);
  nach^.uk := nil;
  nach^.dan := kniga;
  while kniga <> 'ААА' do { формирование списка } 
  begin
    tek := nach;
    New(ob);
    WriteLn(' Введите очередное название ');
    Read(kniga);
    while (tek <> nil) and (tek^.dan < kniga) do { Поиск подходящего места }
    begin
      obpr := tek; { ссылка на предыдущий элемент }
      tek := tek^.uk{ переход к следующему элементу }
    end;
    {вставка нового элемента }
    ob^.uk := tek;
    ob^.dan := kniga;
    if tek = nach then nach := ob
    Else
      obpr^.uk := ob
  end; { конец формирования списка }
  WriteLn(' каталог учебников:'); { вывод на экран дисплея упорядоченного каталога книг }
  tek := nach;
  while tek^.uk <> nil do 
  begin
    WriteLn(tek^.dan);tek := tek^.uk
  end
end.