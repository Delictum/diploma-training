unit Unit12;

interface

uses
  Winapi.Windows, Winapi.Messages, System.SysUtils, System.Variants, System.Classes, Vcl.Graphics,
  Vcl.Controls, Vcl.Forms, Vcl.Dialogs, Vcl.StdCtrls, Vcl.Mask, Vcl.DBCtrls;

type
  TForm12 = class(TForm)
    Button1: TButton;
    Button2: TButton;
    Button3: TButton;
    DBEdit1: TDBEdit;
    procedure Button1Click(Sender: TObject);
    procedure Button2Click(Sender: TObject);
    procedure Button3Click(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form12: TForm12;

implementation

{$R *.dfm}

uses Unit5;

procedure TForm12.Button1Click(Sender: TObject);
 Var BuflevelID : integer;
     BuflevelStr : string;
begin
      FormBegin.SQLQuery2.SQL.Clear;
      FormBegin.SQLQuery2.SQL.Add('INSERT INTO level (levelName) VALUES(');
      FormBegin.SQLQuery2.SQL.Add('"' + DBEdit1.Text + '")');
      FormBegin.SQLQuery2.ExecSQL;

      ShowMessage('���������!');

      FormBegin.ClientDataSet1.Active := false;
      FormBegin.SQLQuery1.Close;
      FormBegin.SQLQuery1.SQL.Clear;
      FormBegin.SQLQuery1.SQL.Add('SELECT * FROM  level');
      FormBegin.SQLQuery1.Open;
      FormBegin.ClientDataSet1.Active := true;
end;

procedure TForm12.Button2Click(Sender: TObject);
 Var BuflevelID : integer;
     BuflevelStr : string;
begin
      FormBegin.SQLQuery2.SQL.Clear;
      FormBegin.SQLQuery2.SQL.Add('UPDATE level SET levelName = "' + DBEdit1.Text + '" WHERE levelID = ' + FormBegin.DBEdit1.Text);
      FormBegin.SQLQuery2.ExecSQL;

      ShowMessage('��������.');

      FormBegin.ClientDataSet1.Active := false;
      FormBegin.SQLQuery1.Close;
      FormBegin.SQLQuery1.SQL.Clear;
      FormBegin.SQLQuery1.SQL.Add('SELECT * FROM  level');
      FormBegin.SQLQuery1.Open;
      FormBegin.ClientDataSet1.Active := true;
end;

procedure TForm12.Button3Click(Sender: TObject);
 Var BuflevelID : integer;
     BuflevelStr : string;
begin
      FormBegin.SQLQuery2.SQL.Clear;
      FormBegin.SQLQuery2.SQL.Add('DELETE FROM level WHERE levelID = ' + FormBegin.DBEdit1.Text);
      FormBegin.SQLQuery2.ExecSQL;

      ShowMessage('�������.');

      FormBegin.ClientDataSet1.Active := false;
      FormBegin.SQLQuery1.Close;
      FormBegin.SQLQuery1.SQL.Clear;
      FormBegin.SQLQuery1.SQL.Add('SELECT * FROM  level');
      FormBegin.SQLQuery1.Open;
      FormBegin.ClientDataSet1.Active := true;
end;

end.
