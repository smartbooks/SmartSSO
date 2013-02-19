-- Start of DDL Script for Table ORAHYD.BASE_ROLE
-- Generated 29-五月-2012 14:28:10 from ORAHYD@ORAHYD

CREATE TABLE orahyd.base_role
    (roleid                         NUMBER NOT NULL,
    rolename                       VARCHAR2(50) NOT NULL,
    roleinfo                       VARCHAR2(500) NOT NULL)
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





-- Constraints for ORAHYD.BASE_ROLE

ALTER TABLE orahyd.base_role
ADD CONSTRAINT pk_base_role PRIMARY KEY (roleid)
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


-- Triggers for ORAHYD.BASE_ROLE

CREATE OR REPLACE TRIGGER ORAHYD.TRG_BASE_ROLE
 BEFORE 
 INSERT
 ON BASE_ROLE
 REFERENCING OLD AS OLD NEW AS NEW
 FOR EACH ROW
DECLARE
   integrity_error   EXCEPTION;
   errno             INTEGER;
   errmsg            CHAR (200);
BEGIN
   SELECT seq_base_ROLE.NEXTVAL
     INTO :NEW.ROLEID
     FROM DUAL;

EXCEPTION
   WHEN integrity_error
   THEN
      raise_application_error (errno, errmsg);
END;
/


-- Comments for ORAHYD.BASE_ROLE

COMMENT ON TABLE orahyd.base_role IS '角色信息表'
/
COMMENT ON COLUMN orahyd.base_role.roleid IS '角色编号'
/
COMMENT ON COLUMN orahyd.base_role.roleinfo IS '角色描述'
/
COMMENT ON COLUMN orahyd.base_role.rolename IS '角色名称'
/

-- End of DDL Script for Table ORAHYD.BASE_ROLE

