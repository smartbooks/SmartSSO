-- Start of DDL Script for Table ORAHYD.BASE_ACTION
-- Generated 29-五月-2012 14:15:06 from ORAHYD@ORAHYD

CREATE TABLE orahyd.base_action
    (actionid                       NUMBER DEFAULT 0 NOT NULL,
    actionname                     VARCHAR2(50) NOT NULL,
    status                         NUMBER DEFAULT 0 NOT NULL,
    actioninfo                     VARCHAR2(50) DEFAULT '无' NOT NULL)
  PCTFREE     10
  INITRANS    1
  MAXTRANS    255
  TABLESPACE  users
  STORAGE   (
    INITIAL     65536
    MINEXTENTS  1
    MAXEXTENTS  2147483645
  )
/





-- Constraints for ORAHYD.BASE_ACTION

ALTER TABLE orahyd.base_action
ADD CONSTRAINT pk_base_action PRIMARY KEY (actionid)
USING INDEX
  PCTFREE     10
  INITRANS    2
  MAXTRANS    255
  TABLESPACE  users
  STORAGE   (
    INITIAL     65536
    MINEXTENTS  1
    MAXEXTENTS  2147483645
  )
/


-- Triggers for ORAHYD.BASE_ACTION

CREATE OR REPLACE TRIGGER TRG_BASE_ACTION
 BEFORE 
 INSERT
 ON BASE_ACTION
 REFERENCING OLD AS OLD NEW AS NEW
 FOR EACH ROW
DECLARE
   integrity_error   EXCEPTION;
   errno             INTEGER;
   errmsg            CHAR (200);
BEGIN
   SELECT seq_base_action.NEXTVAL
     INTO :NEW.ACTIONID
     FROM DUAL;

EXCEPTION
   WHEN integrity_error
   THEN
      raise_application_error (errno, errmsg);
END;
/


-- Comments for ORAHYD.BASE_ACTION

COMMENT ON TABLE orahyd.base_action IS '动作信息表'
/
COMMENT ON COLUMN orahyd.base_action.actionid IS '动作编号'
/
COMMENT ON COLUMN orahyd.base_action.actioninfo IS '动作描述'
/
COMMENT ON COLUMN orahyd.base_action.actionname IS '动作名称'
/
COMMENT ON COLUMN orahyd.base_action.status IS '状态（0：正常 1关闭）'
/

-- End of DDL Script for Table ORAHYD.BASE_ACTION

