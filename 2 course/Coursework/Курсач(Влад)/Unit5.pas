unit Unit5;

interface

uses
  Winapi.Windows, Winapi.Messages, System.SysUtils, System.Variants, System.Classes, Vcl.Graphics,
  Vcl.Controls, Vcl.Forms, Vcl.Dialogs, Vcl.ComCtrls, Data.FMTBcd, DBXMySQL,
  Vcl.StdCtrls, Vcl.DBCtrls, Data.DB, Data.SqlExpr, Datasnap.Provider,
  Datasnap.DBClient, Vcl.Mask;

type
  TFormBegin = class(TForm)
    DataSource1: TDataSource;
    ClientDataSet1: TClientDataSet;
    DataSetProvider1: TDataSetProvider;
    SQLQuery1: TSQLQuery;
    SQLConnection1: TSQLConnection;
    Label1: TLabel;
    Ok: TButton;
    DBLCBLevel: TDBLookupComboBox;
    DataSource2: TDataSource;
    ClientDataSet2: TClientDataSet;
    DataSetProvider2: TDataSetProvider;
    SQLQuery2: TSQLQuery;
    SQLConnection2: TSQLConnection;
    Button1: TButton;
    DBEdit1: TDBEdit;
    procedure FormClose(Sender: TObject; var Action: TCloseAction);
    procedure OkClick(Sender: TObject);
    procedure Button1Click(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  FormBegin: TFormBegin;
  Otvet, GameStepID : integer;

implementation

{$R *.dfm}

uses Unit3, Unit6, Unit7, Unit8, Unit12;

procedure TFormBegin.Button1Click(Sender: TObject);
begin
  Form12.Show;
end;

procedure TFormBegin.FormClose(Sender: TObject; var Action: TCloseAction);
begin
  LogOut.Close;
end;

procedure TFormBegin.OkClick(Sender: TObject);
begin
if DBLCBLevel.Text <> '' then
    begin
      if DBLCBLevel.Text = '����������' then
        begin
          FormGame1.PageControl1.ActivePageIndex := 0;
          GameStepID := 1;
          FormBegin.Hide;
          FormGame1.Show;
        end;
      if DBLCBLevel.Text = 'IT-����������' then
        begin
          GameStepID := 11;
          FormGame2.PageControl1.ActivePageIndex := 0;
          FormBegin.Hide;
          FormGame2.Show;
        end;
      if DBLCBLevel.Text = '�������' then
        begin
          GameStepID := 21;
          FormGame3.PageControl1.ActivePageIndex := 0;
          FormBegin.Hide;
          FormGame3.Show;
        end;
      FormGame1.ClientDataSet1.Active := false;
      FormGame1.SQLQuery1.Close;
      FormGame1.SQLQuery1.SQL.Clear;
      FormGame1.SQLQuery1.SQL.Add('SELECT *  FROM Answers WHERE AnswersQuestionsID = ' + IntToStr(GameStepID));
      FormGame1.SQLQuery1.Open;
      FormGame1.ClientDataSet1.Active := true;

      FormGame1.ClientDataSet2.Active := false;
      FormGame1.SQLQuery2.Close;
      FormGame1.SQLQuery2.SQL.Clear;
      FormGame1.SQLQuery2.SQL.Add('SELECT *  FROM Questions WHERE QuestionsID = ' + IntToStr(GameStepID));
      FormGame1.SQLQuery2.Open;
      FormGame1.ClientDataSet2.Active := true;
    end
  else
  begin
    ShowMessage('�������� �������.');
    exit;
  end;
  ShowMessage('������� � ����������.');
end;

end.
