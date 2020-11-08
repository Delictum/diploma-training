unit Unit6;

interface

uses
  Winapi.Windows, Winapi.Messages, System.SysUtils, System.Variants, System.Classes, Vcl.Graphics,
  Vcl.Controls, Vcl.Forms, Vcl.Dialogs, Data.DB, Vcl.Grids, Vcl.DBGrids,
  Vcl.ComCtrls, Vcl.StdCtrls, Vcl.Imaging.jpeg, Vcl.Imaging.pngimage,
  Vcl.ExtCtrls, Data.FMTBcd, DBXMySQL, Vcl.DBCtrls, Data.SqlExpr,
  Datasnap.Provider, Datasnap.DBClient;

type
  TFormGame1 = class(TForm)
    PageControl1: TPageControl;
    TabSheet1: TTabSheet;
    TabSheet2: TTabSheet;
    TabSheet3: TTabSheet;
    TabSheet4: TTabSheet;
    TabSheet5: TTabSheet;
    TabSheet6: TTabSheet;
    TabSheet7: TTabSheet;
    TabSheet8: TTabSheet;
    TabSheet9: TTabSheet;
    TabSheet10: TTabSheet;
    DataSource2: TDataSource;
    ClientDataSet2: TClientDataSet;
    DataSetProvider2: TDataSetProvider;
    SQLQuery2: TSQLQuery;
    SQLConnection2: TSQLConnection;
    Image1: TImage;
    DBRichEdit1: TDBRichEdit;
    SQLConnection1: TSQLConnection;
    SQLQuery1: TSQLQuery;
    DataSetProvider1: TDataSetProvider;
    ClientDataSet1: TClientDataSet;
    DataSource1: TDataSource;
    DBRichEdit2: TDBRichEdit;
    RichEdit1: TRichEdit;
    RichEdit2: TRichEdit;
    RichEdit3: TRichEdit;
    DBRichEdit3: TDBRichEdit;
    DBRichEdit4: TDBRichEdit;
    Image2: TImage;
    RichEdit4: TRichEdit;
    RichEdit5: TRichEdit;
    RichEdit6: TRichEdit;
    DBRichEdit5: TDBRichEdit;
    DBRichEdit6: TDBRichEdit;
    RichEdit7: TRichEdit;
    RichEdit8: TRichEdit;
    RichEdit9: TRichEdit;
    Image3: TImage;
    DBRichEdit7: TDBRichEdit;
    DBRichEdit8: TDBRichEdit;
    RichEdit10: TRichEdit;
    RichEdit11: TRichEdit;
    RichEdit12: TRichEdit;
    Image4: TImage;
    DBRichEdit9: TDBRichEdit;
    DBRichEdit10: TDBRichEdit;
    RichEdit13: TRichEdit;
    RichEdit14: TRichEdit;
    RichEdit15: TRichEdit;
    Image5: TImage;
    DBRichEdit11: TDBRichEdit;
    DBRichEdit12: TDBRichEdit;
    RichEdit16: TRichEdit;
    RichEdit17: TRichEdit;
    RichEdit18: TRichEdit;
    Image6: TImage;
    DBRichEdit13: TDBRichEdit;
    DBRichEdit14: TDBRichEdit;
    RichEdit19: TRichEdit;
    RichEdit20: TRichEdit;
    RichEdit21: TRichEdit;
    Image7: TImage;
    DBRichEdit15: TDBRichEdit;
    DBRichEdit16: TDBRichEdit;
    RichEdit22: TRichEdit;
    RichEdit23: TRichEdit;
    RichEdit24: TRichEdit;
    Image8: TImage;
    DBRichEdit17: TDBRichEdit;
    DBRichEdit18: TDBRichEdit;
    RichEdit25: TRichEdit;
    RichEdit26: TRichEdit;
    RichEdit27: TRichEdit;
    Image9: TImage;
    DBRichEdit19: TDBRichEdit;
    DBRichEdit20: TDBRichEdit;
    RichEdit28: TRichEdit;
    RichEdit29: TRichEdit;
    RichEdit30: TRichEdit;
    Image10: TImage;
    procedure DBRichEdit2Click(Sender: TObject);
    procedure RichEdit2Click(Sender: TObject);
    procedure FormClose(Sender: TObject; var Action: TCloseAction);
    procedure RichEdit2Change(Sender: TObject);
    procedure RichEdit3Change(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  FormGame1: TFormGame1;

implementation

{$R *.dfm}

uses Unit5, Unit9;

procedure TFormGame1.DBRichEdit2Click(Sender: TObject);
begin
  inc(GameStepID);

  ClientDataSet1.Active := false;
  SQLQuery1.Close;
  SQLQuery1.SQL.Clear;
  SQLQuery1.SQL.Add('SELECT *  FROM Answers WHERE AnswersQuestionsID = ' + IntToStr(GameStepID));
  SQLQuery1.Open;
  ClientDataSet1.Active := true;

  ClientDataSet2.Active := false;
  SQLQuery2.Close;
  SQLQuery2.SQL.Clear;
  SQLQuery2.SQL.Add('SELECT *  FROM Questions WHERE QuestionsID = ' + IntToStr(GameStepID));
  SQLQuery2.Open;
  ClientDataSet2.Active := true;

  Otvet := Otvet + sqr(Otvet) + 1;

  if PageControl1.ActivePageIndex = 9 then
    begin
      FormGame1.Hide;
      FormEnd.Show;
      exit;
    end;

  PageControl1.ActivePageIndex := PageControl1.ActivePageIndex + 1;
end;

procedure TFormGame1.FormClose(Sender: TObject; var Action: TCloseAction);
begin
  FormBegin.Close;
end;

procedure TFormGame1.RichEdit2Change(Sender: TObject);
begin
  FormGame1.Hide;
  FormEnd.Show;
end;

procedure TFormGame1.RichEdit2Click(Sender: TObject);
begin
  FormGame1.Hide;
  FormEnd.Show;
end;

procedure TFormGame1.RichEdit3Change(Sender: TObject);
begin
  FormGame1.Hide;
  FormEnd.Show;
end;

end.
