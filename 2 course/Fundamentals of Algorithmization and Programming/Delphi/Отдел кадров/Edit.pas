unit Edit;

interface

uses
  Winapi.Windows, Winapi.Messages, System.SysUtils, System.Variants, System.Classes, Vcl.Graphics,
  Vcl.Controls, Vcl.Forms, Vcl.Dialogs, Vcl.StdCtrls, Vcl.DBCtrls, Vcl.Mask,
  Data.DB, Vcl.Grids, Vcl.DBGrids, Vcl.ExtCtrls;

type
  TFEditor = class(TForm)
    GroupBox1: TGroupBox;
    GroupBox2: TGroupBox;
    GroupBox3: TGroupBox;
    GroupBox4: TGroupBox;
    DBEdit2: TDBEdit;
    DBEdit3: TDBEdit;
    DBEdit4: TDBEdit;
    DBEdit5: TDBEdit;
    DBEdit6: TDBEdit;
    DBEdit7: TDBEdit;
    DBEdit8: TDBEdit;
    DBComboBox1: TDBComboBox;
    Label1: TLabel;
    Label2: TLabel;
    Label3: TLabel;
    Label4: TLabel;
    Label5: TLabel;
    Label6: TLabel;
    Label7: TLabel;
    Label8: TLabel;
    Label9: TLabel;
    DBEdit1: TDBEdit;
    DBEdit9: TDBEdit;
    DBEdit10: TDBEdit;
    Label10: TLabel;
    Label11: TLabel;
    DBEdit11: TDBEdit;
    DBEdit12: TDBEdit;
    DBEdit13: TDBEdit;
    Label12: TLabel;
    Label13: TLabel;
    Label14: TLabel;
    DBEdit14: TDBEdit;
    Label15: TLabel;
    DBComboBox2: TDBComboBox;
    Label16: TLabel;
    Button1: TButton;
    DBGrid1: TDBGrid;
    DBCheckBox1: TDBCheckBox;
    DBCheckBox2: TDBCheckBox;
    DBNavigator1: TDBNavigator;
    Label17: TLabel;
    Button2: TButton;
    Button3: TButton;
    procedure GroupBox1Exit(Sender: TObject);
    procedure Button1Click(Sender: TObject);
    procedure Button2Click(Sender: TObject);
    procedure Button3Click(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  FEditor: TFEditor;

implementation

{$R *.dfm}

uses Main;

procedure TFEditor.Button1Click(Sender: TObject);
begin
  if FName.TTelphones.Modified then
    FName.TTelphones.Post;
  FName.TTelphones.Append;
  DBEdit14.SetFocus;
end;

procedure TFEditor.Button2Click(Sender: TObject);
begin
  if FName.TLichData.Modified then
    FName.TLichData.Post;
  if FName.TDoljnost.Modified then
    FName.TDoljnost.Post;
  if FName.TAdress.Modified then
    FName.TAdress.Post;
  if FName.TTelphones.Modified then
    FName.TTelphones.Post;
  Close;
end;

procedure TFEditor.Button3Click(Sender: TObject);
begin
  FName.TLichData.Append;
  FName.TDoljnost.Append;
  FName.TAdress.Append;
  FName.TTelphones.Append;
  DbEdit1.SetFocus;
end;

procedure TFEditor.GroupBox1Exit(Sender: TObject);
begin
  if FName.TLichData.Modified then
    FName.TLichData.Post;
end;

end.
