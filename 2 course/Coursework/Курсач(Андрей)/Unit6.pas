unit Unit6;

interface

uses
  Winapi.Windows, Winapi.Messages, System.SysUtils, System.Variants, System.Classes, Vcl.Graphics,
  Vcl.Controls, Vcl.Forms, Vcl.Dialogs, DBXMySQL, Data.FMTBcd, Vcl.StdCtrls,
  Vcl.Mask, Vcl.DBCtrls, Data.DB, Datasnap.DBClient, Datasnap.Provider,
  Data.SqlExpr, Vcl.ExtCtrls;

type
  TForm6 = class(TForm)
    SQLConnection1: TSQLConnection;
    SQLQuery1: TSQLQuery;
    DataSetProvider1: TDataSetProvider;
    ClientDataSet1: TClientDataSet;
    DataSource1: TDataSource;
    DBEdit1: TDBEdit;
    SQLQuery2: TSQLQuery;
    DataSetProvider2: TDataSetProvider;
    ClientDataSet2: TClientDataSet;
    DataSource2: TDataSource;
    DBEdit2: TDBEdit;
    Label1: TLabel;
    Label2: TLabel;
    Edit1: TEdit;
    Edit2: TEdit;
    Label3: TLabel;
    Label4: TLabel;
    Label5: TLabel;
    Label6: TLabel;
    ButtonAdd1: TButton;
    ButtonEdd1: TButton;
    ButtonDel1: TButton;
    ButtonDel2: TButton;
    ButtonEdd2: TButton;
    ButtonAdd2: TButton;
    Bevel1: TBevel;
    procedure ButtonAdd1Click(Sender: TObject);
    procedure ButtonAdd2Click(Sender: TObject);
    procedure ButtonEdd1Click(Sender: TObject);
    procedure ButtonEdd2Click(Sender: TObject);
    procedure ButtonDel1Click(Sender: TObject);
    procedure ButtonDel2Click(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form6: TForm6;
  bufMaxID : integer;

implementation

{$R *.dfm}

uses Unit3;

procedure TForm6.ButtonAdd1Click(Sender: TObject);
Var buf : string;
begin
  if Edit2.Text = '' then
  begin
    ShowMessage('Введите новый уровень.');
    exit;
  end;
  ClientDataSet2.Active := false;
   SQLQuery2.Close;
    SQLQuery2.SQL.Clear;
     SQLQuery2.SQL.Add('SELECT Max(ID) AS ID FROM Level');
      SQLQuery2.Open;
       ClientDataSet2.Active := true;
  buf := VarToStr(SQLQuery2.FieldValues['ID']);
  bufMaxID := StrToInt(buf) + 1;
    SQLQuery2.SQL.Clear;
     SQLQuery2.SQL.Add('INSERT INTO Level(ID, Name_Level) VALUES(');
      SQLQuery2.SQL.Add(IntToStr(bufMaxID) + ', "' + Edit2.Text + '")');
       SQLQuery2.ExecSQL;
  FormBegin.CBLevel.Items.Add(Edit2.Text);
  ShowMessage('Добавлено.');
end;

procedure TForm6.ButtonAdd2Click(Sender: TObject);
Var buf : string;
begin
  if Edit1.Text = '' then
  begin
    ShowMessage('Введите новый жанр.');
    exit;
  end;
  if Edit2.Text = '' then
  begin
    ShowMessage('Введите уровень жанра.');
    exit;
  end;

  ClientDataSet2.Active := false;
   SQLQuery2.Close;
    SQLQuery2.SQL.Clear;
     SQLQuery2.SQL.Add('SELECT Max(ID) AS ID FROM Genre');
      SQLQuery2.Open;
       ClientDataSet2.Active := true;
  buf := VarToStr(SQLQuery2.FieldValues['ID']);
  bufMaxID := StrToInt(buf) + 1;

  ClientDataSet2.Active := false;
   SQLQuery2.Close;
    SQLQuery2.SQL.Clear;
     SQLQuery2.SQL.Add('SELECT ID FROM Level WHERE Name_Level = "' + Edit2.Text + '"');
      SQLQuery2.Open;
       ClientDataSet2.Active := true;
  buf := VarToStr(SQLQuery2.FieldValues['ID']);

   SQLQuery2.SQL.Clear;
    SQLQuery2.SQL.Add('INSERT INTO Genre(ID, ID_Level, Name_Genre) VALUES(');
     SQLQuery2.SQL.Add(IntToStr(bufMaxID) + ', ' + buf + ', "' + Edit1.Text + '")');
      SQLQuery2.ExecSQL;

  FormBegin.ClientDataSet1.Active := false;
  FormBegin.SQLQuery1.Close;
  FormBegin.SQLQuery1.SQL.Clear;
  FormBegin.SQLQuery1.SQL.Add('SELECT *  FROM Genre');
  FormBegin.SQLQuery1.Open;
  FormBegin.ClientDataSet1.Active := true;
  FormBegin.DBLCBGenre.Refresh;

  ShowMessage('Добавлено.');
end;

procedure TForm6.ButtonDel1Click(Sender: TObject);
begin
  if Edit2.Text = '' then
  begin
    ShowMessage('Введите удаляемый уровень.');
    exit;
  end;
  SQLQuery2.SQL.Clear;
    SQLQuery2.SQL.Add('DELETE FROM Level WHERE Name_Level = "' + Edit2.Text + '"');
      SQLQuery2.ExecSQL;
  ShowMessage('Удалено.');
end;

procedure TForm6.ButtonDel2Click(Sender: TObject);
begin
  if Edit1.Text = '' then
  begin
    ShowMessage('Введите удаляемый жанр.');
    exit;
  end;
  SQLQuery2.SQL.Clear;
    SQLQuery2.SQL.Add('DELETE FROM Genre WHERE Name_Genre = "' + Edit1.Text + '"');
      SQLQuery2.ExecSQL;
  ShowMessage('Удалено.');
end;

procedure TForm6.ButtonEdd1Click(Sender: TObject);
begin
  if DBEdit2.Text = '' then
  begin
    ShowMessage('Введите изменяемый уровень.');
    exit;
  end;
  if Edit2.Text = '' then
  begin
    ShowMessage('Введите новое название уровня.');
    exit;
  end;
  SQLQuery2.SQL.Clear;
    SQLQuery2.SQL.Add('UPDATE Level SET  Name_Level = "' + Edit2.Text + '" WHERE Name_Level = "' + DBEdit2.Text + '"');
      SQLQuery2.ExecSQL;
  ShowMessage('Изменено.');
end;

procedure TForm6.ButtonEdd2Click(Sender: TObject);
begin
  if DBEdit1.Text = '' then
  begin
    ShowMessage('Введите изменяемый жанр.');
    exit;
  end;
  if Edit1.Text = '' then
  begin
    ShowMessage('Введите новое название жанра.');
    exit;
  end;
  SQLQuery2.SQL.Clear;
    SQLQuery2.SQL.Add('UPDATE Genre SET  Name_Genre = "' + Edit1.Text + '" WHERE Name_Genre = "' + DBEdit1.Text + '"');
      SQLQuery2.ExecSQL;

  FormBegin.ClientDataSet1.Active := false;
  FormBegin.SQLQuery1.Close;
  FormBegin.SQLQuery1.SQL.Clear;
  FormBegin.SQLQuery1.SQL.Add('SELECT *  FROM Genre');
  FormBegin.SQLQuery1.Open;
  FormBegin.ClientDataSet1.Active := true;
  FormBegin.DBLCBGenre.Refresh;

  ShowMessage('Изменено.');
end;

end.
