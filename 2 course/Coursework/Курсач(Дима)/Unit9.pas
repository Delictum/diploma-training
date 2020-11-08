unit Unit9;

interface

uses
  Winapi.Windows, Winapi.Messages, System.SysUtils, System.Variants, System.Classes, Vcl.Graphics,
  Vcl.Controls, Vcl.Forms, Vcl.Dialogs, Vcl.ExtCtrls, Vcl.StdCtrls, Vcl.Mask,
  Vcl.DBCtrls;

type
  TFormNew = class(TForm)
    DBEdit1: TDBEdit;
    DBEdit2: TDBEdit;
    Button1: TButton;
    Button2: TButton;
    Button3: TButton;
    Button4: TButton;
    Button5: TButton;
    Button6: TButton;
    Bevel1: TBevel;
    DBLCBTypeNebesTela: TDBLookupComboBox;
    DBLCBGolak: TDBLookupComboBox;
    procedure Button1Click(Sender: TObject);
    procedure Button4Click(Sender: TObject);
    procedure Button2Click(Sender: TObject);
    procedure Button5Click(Sender: TObject);
    procedure Button3Click(Sender: TObject);
    procedure Button6Click(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  FormNew: TFormNew;

implementation

{$R *.dfm}

uses Unit8, Unit1;

procedure TFormNew.Button1Click(Sender: TObject);
 Var BuftypenebestelaID : integer;
     BuftypenebestelaStr : string;
begin
      BuftypenebestelaID := 0;
      BuftypenebestelaStr := '';
      Form8.ClientDataSet1.Active := false;
      Form8.SQLQuery1.Close;
      Form8.SQLQuery1.SQL.Clear;
      Form8.SQLQuery1.SQL.Add('SELECT MAX(typenebestela_id) AS ID FROM typenebestela');
      Form8.SQLQuery1.Open;
      Form8.ClientDataSet1.Active := true;
      BuftypenebestelaStr := IntToStr(Form8.SQLQuery1.FieldValues['ID']);
      BuftypenebestelaID := StrToInt(BuftypenebestelaStr) + 1;

      Form8.SQLQuery1.SQL.Clear;
      Form8.SQLQuery1.SQL.Add('INSERT INTO typenebestela (typenebestela_id, typenebestela) VALUES(');
      Form8.SQLQuery1.SQL.Add(IntToStr(BuftypenebestelaID) + ', "' + DBEdit1.Text + '")');
      Form8.SQLQuery1.ExecSQL;

      ShowMessage('���������!');

      Form8.ClientDataSet2.Active := false;
      Form8.SQLQuery2.Close;
      Form8.SQLQuery2.SQL.Clear;
      Form8.SQLQuery2.SQL.Add('SELECT * FROM  typenebestela');
      Form8.SQLQuery2.Open;
      Form8.ClientDataSet2.Active := true;
end;

procedure TFormNew.Button2Click(Sender: TObject);
Var BuftypenebestelaStr : string;
    BuftypenebestelaID, i : integer;
begin
      BuftypenebestelaID := 0;
      BuftypenebestelaStr := '';
      Form8.ClientDataSet1.Active := false;
      Form8.SQLQuery1.Close;
      Form8.SQLQuery1.SQL.Clear;
      Form8.SQLQuery1.SQL.Add('SELECT MAX(typenebestela_id) AS ID FROM typenebestela');
      Form8.SQLQuery1.Open;
      Form8.ClientDataSet1.Active := true;
      BuftypenebestelaStr := IntToStr(Form8.SQLQuery1.FieldValues['ID']);
      BuftypenebestelaID := StrToInt(BuftypenebestelaStr) + 1;

      Form8.SQLQuery1.Close;
      Form8.SQLQuery1.SQL.Clear;
      Form8.SQLQuery1.SQL.Add('UPDATE typenebestela SET typenebestela = "' + DBEdit1.Text + '" WHERE typenebestela_ID = ' + Form8.DBEdit2.Text);
      Form8.SQLQuery1.ExecSQL;

      ShowMessage('��������!');

      Form8.ClientDataSet2.Active := false;
      Form8.SQLQuery2.Close;
      Form8.SQLQuery2.SQL.Clear;
      Form8.SQLQuery2.SQL.Add('SELECT * FROM  typenebestela');
      Form8.SQLQuery2.Open;
      Form8.ClientDataSet2.Active := true;
end;

procedure TFormNew.Button3Click(Sender: TObject);
begin
  Form8.SQLQuery1.Close;
      Form8.SQLQuery1.SQL.Clear;
      Form8.SQLQuery1.SQL.Add('DELETE FROM typenebestela WHERE typenebestela_ID = ' + Form8.DBEdit2.Text);
      Form8.SQLQuery1.ExecSQL;

      ShowMessage('�������!');

      Form8.ClientDataSet2.Active := false;
      Form8.SQLQuery2.Close;
      Form8.SQLQuery2.SQL.Clear;
      Form8.SQLQuery2.SQL.Add('SELECT * FROM  typenebestela');
      Form8.SQLQuery2.Open;
      Form8.ClientDataSet2.Active := true;
end;

procedure TFormNew.Button4Click(Sender: TObject);
Var BufgolakID : integer;
     BufgolakStr : string;
begin
      BufgolakID := 0;
      BufgolakStr := '';
      Form8.ClientDataSet1.Active := false;
      Form8.SQLQuery1.Close;
      Form8.SQLQuery1.SQL.Clear;
      Form8.SQLQuery1.SQL.Add('SELECT MAX(golak_id) AS ID FROM golak');
      Form8.SQLQuery1.Open;
      Form8.ClientDataSet1.Active := true;
      BufgolakStr := IntToStr(Form8.SQLQuery1.FieldValues['ID']);
      BufgolakID := StrToInt(BufgolakStr) + 1;

      Form8.SQLQuery1.SQL.Clear;
      Form8.SQLQuery1.SQL.Add('INSERT INTO golak (golak_id, galak_name) VALUES(');
      Form8.SQLQuery1.SQL.Add(IntToStr(BufgolakID) + ', "' + DBEdit2.Text + '")');
      Form8.SQLQuery1.ExecSQL;

      ShowMessage('���������!');

      Form8.ClientDataSet3.Active := false;
      Form8.SQLQuery3.Close;
      Form8.SQLQuery3.SQL.Clear;
      Form8.SQLQuery3.SQL.Add('SELECT * FROM  golak');
      Form8.SQLQuery3.Open;
      Form8.ClientDataSet3.Active := true;
end;

procedure TFormNew.Button5Click(Sender: TObject);
Var BufgolakStr : string;
    BufgolakID, i : integer;
begin
      BufgolakID := 0;
      BufgolakStr := '';
      Form8.ClientDataSet1.Active := false;
      Form8.SQLQuery1.Close;
      Form8.SQLQuery1.SQL.Clear;
      Form8.SQLQuery1.SQL.Add('SELECT MAX(golak_id) AS ID FROM golak');
      Form8.SQLQuery1.Open;
      Form8.ClientDataSet1.Active := true;
      BufgolakStr := IntToStr(Form8.SQLQuery1.FieldValues['ID']);
      BufgolakID := StrToInt(BufgolakStr) + 1;

      Form8.SQLQuery1.Close;
      Form8.SQLQuery1.SQL.Clear;
      Form8.SQLQuery1.SQL.Add('UPDATE golak SET galak_name = "' + DBEdit2.Text + '" WHERE golak_ID = ' + Form8.DBEdit3.Text);
      Form8.SQLQuery1.ExecSQL;

      ShowMessage('��������!');

      Form8.ClientDataSet3.Active := false;
      Form8.SQLQuery3.Close;
      Form8.SQLQuery3.SQL.Clear;
      Form8.SQLQuery3.SQL.Add('SELECT * FROM  golak');
      Form8.SQLQuery3.Open;
      Form8.ClientDataSet3.Active := true;
end;

procedure TFormNew.Button6Click(Sender: TObject);
begin
Form8.SQLQuery1.Close;
      Form8.SQLQuery1.SQL.Clear;
      Form8.SQLQuery1.SQL.Add('DELETE FROM golak WHERE golak_ID = ' + Form8.DBEdit3.Text);
      Form8.SQLQuery1.ExecSQL;

      ShowMessage('�������!');

      Form8.ClientDataSet3.Active := false;
      Form8.SQLQuery3.Close;
      Form8.SQLQuery3.SQL.Clear;
      Form8.SQLQuery3.SQL.Add('SELECT * FROM  golak');
      Form8.SQLQuery3.Open;
      Form8.ClientDataSet3.Active := true;
end;

end.
