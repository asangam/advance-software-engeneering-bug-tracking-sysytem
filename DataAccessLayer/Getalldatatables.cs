﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace DataAccessLayer
{
    public class Getalldatatables
    {

        SqlConnection conn = new SqlConnection(ConnectionClass.ConnectionString);

        public DataTable getAllUsers()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlCommand cmd = new SqlCommand("select u.userId as Id,m.memberName as Name,u.userName as Username,u.userPassword as Password, r.userRole as Role from UserTable u, MemberTable m, UserRoleTable r where u.userRoleId=r.userRoleId and u.memberId=m.memberId", conn);
                cmd.CommandType = CommandType.Text;
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                dt.Load(dr);
                conn.Close();
                return dt;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { conn.Close(); }
        }

        public DataTable getalluserroles()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlCommand cmd = new SqlCommand("select * from UserRoleTable", conn);
                cmd.CommandType = CommandType.Text;
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                dt.Load(dr);
                conn.Close();
                return dt;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { conn.Close(); }
        }

        public DataTable userType(String userName, String userPassword)
        {
            try
            {
                DataTable dt = new DataTable();

                SqlCommand cmd = new SqlCommand("select userRoleId,userName,userPassword from UserTable where userName=@userName,userPassword=@userPassword", conn);
                //SqlCommand cmd = new SqlCommand("select userRole from UserRoleTable where userRoleId=(select userRoleId from UserTable where userName=@userName and userPassword=@userPassword)", conn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@userName", userName);
                cmd.Parameters.AddWithValue("@userPassword", userPassword);
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                dt.Load(dr);
                conn.Close();

                return dt;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { conn.Close(); }
        }
        public DataTable getAllMembers()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlCommand cmd = new SqlCommand("Select * from MemberTable", conn);
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                dt.Load(dr);
                conn.Close();
                return dt;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { conn.Close(); }

        }

        public DataTable getAllUserRoles()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlCommand cmd = new SqlCommand("SELECT * FROM UserRoleTable", conn);
                cmd.CommandType = CommandType.Text;
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                dt.Load(dr);
                conn.Close();
                return dt;
            }
            catch (Exception ex)
            {

                throw ex;
            }




        }

        public DataTable getAllProjects()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlCommand cmd = new SqlCommand("Select * from ProjectTable", conn);
                cmd.CommandType = CommandType.Text;
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                dt.Load(dr);
                conn.Close();
                return dt;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { conn.Close(); }
        }


        public DataTable getAllMembersInProject()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlCommand cmd = new SqlCommand("SELECT mp.id,p.projectName,m.memberName,mp.memberRole,mp.memberResponsibilities FROM MemberInProjectTable mp, ProjectTable p, MemberTable m WHERE mp.projectId=p.projectId AND mp.memberId=m.memberId", conn);
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                dt.Load(dr);
                conn.Close();
                return dt;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { conn.Close(); }
        }

        public DataTable GetProjectBymemberId(int memberId)
        {
            try
            {
                DataTable dt = new DataTable();
                SqlCommand cmd = new SqlCommand("Select p.ProjectName,p.ProjectId from ProjectMemberTable pm,ProjectTable p where memberId=@memberId and p.ProjectId=pm.ProjectId", conn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@memberId", memberId);
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                dt.Load(dr);
                conn.Close();
                return dt;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { conn.Close(); }
        }
        public DataTable getProjectMemberByProjectId(int projectId)
        {
            try
            {
                DataTable dt = new DataTable();
                SqlCommand cmd = new SqlCommand("Select * from MemberInProjectTable where projectId=@projectId", conn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@projectId", projectId);
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                dt.Load(dr);
                conn.Close();
                return dt;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { conn.Close(); }
        }

        public int totalProjectMember()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlCommand cmd = new SqlCommand("Select count(*) from ProjectMemberTable", conn);
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                dt.Load(dr);
                conn.Close();
                int x = Convert.ToInt32(dt.Rows[0][0].ToString());
                return x;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { conn.Close(); }
        }

        public DataTable getAllBugs()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlCommand cmd = new SqlCommand("select b.bugId, b.bugIdentifiedDate, m.memberName, p.projectName, b.classLibraryName,b.className,b.methodName, b.blockName, b.lineNumber, b.bugDetails, b.snapShotOfBugMessage, b.codeContainingBug from BugEntryTable b, MemberTable m, ProjectTable p where b.memberId=m.memberId and b.projectId=p.projectId", conn);
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                dt.Load(dr);
                conn.Close();
                return dt;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { conn.Close(); }
        }
        public int bugsCount()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlCommand cmd = new SqlCommand("Select count(*) from BugTable", conn);
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                dt.Load(dr);
                conn.Close();
                int totalBugs = Convert.ToInt32(dt.Rows[0][0].ToString());
                return totalBugs;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { conn.Close(); }
        }
        public DataTable getBugsBymemberId(int memberId)
        {
            try
            {
                DataTable dt = new DataTable();
                SqlCommand cmd = new SqlCommand("Select * from BugTable where memberId=@memberId", conn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@memberId", memberId);
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                dt.Load(dr);
                conn.Close();
                return dt;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { conn.Close(); }
        }
        public DataTable getBugsInProjectByProjectId(int projectId)
        {
            try
            {
                DataTable dt = new DataTable();
                SqlCommand cmd = new SqlCommand("select * from BugEntryTable where projectId=@projectId", conn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@projectId", projectId);
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                dt.Load(dr);
                conn.Close();
                return dt;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { conn.Close(); }
        }

        public DataTable getBugsByMemberAndProject(int memberId, int projectId)
        {
            try
            {
                DataTable dt = new DataTable();
                SqlCommand cmd = new SqlCommand("Select bugId,bugDetails from BugTable where memberId=@memberId and projectId=@projectId", conn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@memberId", memberId);
                cmd.Parameters.AddWithValue("@projectId", projectId);
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                dt.Load(dr);
                conn.Close();
                return dt;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { conn.Close(); }
        }
        public DataTable getAllBugSolutions()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlCommand cmd = new SqlCommand("select b.bugSolutionId,b.dateOfSolutionIdentified,m.memberName, p.projectName,e.bugDetails,e.snapShotOfBugMessage,b.solutionDetails,b.codeAfterFixingBug from BugSolutionTable b,BugEntryTable e, ProjectTable p, MemberTable m where b.bugId=e.bugId and b.projectId=p.projectId and b.memberId=m.memberId", conn);
                cmd.CommandType = CommandType.Text;
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                dt.Load(dr);
                conn.Close();
                return dt;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { conn.Close(); }
        }
        public DataTable searchBugSolutionByBugDetails(String bugDetails)
        {
            try
            {
                DataTable dt = new DataTable();
                SqlCommand cmd = new SqlCommand("select b.bugSolutionId,b.dateOfSolutionIdentified,m.memberName, p.projectName,e.bugDetails,e.snapShotOfBugMessage,b.solutionDetails,b.codeAfterFixingBug from BugSolutionTable b,BugEntryTable e, ProjectTable p, MemberTable m where b.bugId=e.bugId and b.projectId=p.projectId and b.memberId=m.memberId and e.bugDetails like @bugDetails + '%' ", conn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@bugDetails", bugDetails);
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                dt.Load(dr);
                conn.Close();
                return dt;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { conn.Close(); }
        }
        public int countNumberOfProjects()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlCommand cmd = new SqlCommand("Select count(*) from ProjectTable", conn);
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                dt.Load(dr);
                conn.Close();
                int numberOfProjects = Convert.ToInt32(dt.Rows[0][0].ToString());
                return numberOfProjects;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { conn.Close(); }
        }

        public int totalMember()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlCommand cmd = new SqlCommand("Select count(*) from MemberTable", conn);
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                dt.Load(dr);
                conn.Close();
                int Total = Convert.ToInt32(dt.Rows[0][0].ToString());
                return Total;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { conn.Close(); }

        }

        public string Login(String userName, String userPassword)
        {
            try
            {
                string role = "";
                DataTable dt = new DataTable();
              //  select userName, userPassword from UserTable where userName = @userName and userPassword = @userPassword
                SqlCommand cmd = new SqlCommand("select ur.userRole,u.userName, u.userPassword, u.userRoleId from UserTable u, UserRoleTable ur where u.userRoleId=ur.userRoleId and userName=@userName and userPassword=@userPassword ", conn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@userName", userName);
                cmd.Parameters.AddWithValue("@userPassword", userPassword);
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                dt.Load(dr);
                conn.Close();
                if (dt.Rows.Count > 0)
                    role = dt.Rows[0][0].ToString();
                else
                    role = "";
                return role;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { conn.Close(); }
        }
    }
}

