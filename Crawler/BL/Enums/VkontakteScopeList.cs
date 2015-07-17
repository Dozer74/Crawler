using System;

namespace Crawler.BL.Enums
{
    [Flags]
    internal enum VkontakteScopeList
    {
        /// <summary>
        ///     ������������ �������� ���������� ��� �����������.
        /// </summary>
        notify = 1,

        /// <summary>
        ///     ������ � �������.
        /// </summary>
        friends = 2,

        /// <summary>
        ///     ������ � �����������.
        /// </summary>
        photos = 4,

        /// <summary>
        ///     ������ � ������������.
        /// </summary>
        audio = 8,

        /// <summary>
        ///     ������ � ������������.
        /// </summary>
        video = 16,

        /// <summary>
        ///     ������ � ������������ (���������� ������).
        /// </summary>
        offers = 32,

        /// <summary>
        ///     ������ � �������� (���������� ������).
        /// </summary>
        questions = 64,

        /// <summary>
        ///     ������ � wiki-���������.
        /// </summary>
        pages = 128,

        /// <summary>
        ///     ���������� ������ �� ���������� � ���� �����.
        /// </summary>
        link = 256,

        /// <summary>
        ///     ������ �������� ������������.
        /// </summary>
        notes = 2048,

        /// <summary>
        ///     (��� Standalone-����������) ������ � ����������� ������� ������ � �����������.
        /// </summary>
        messages = 4096,

        /// <summary>
        ///     ������ � ������� � ����������� ������� ������ �� ������.
        /// </summary>
        wall = 8192,

        /// <summary>
        ///     ������ � ���������� ������������.
        /// </summary>
        docs = 131072,

        /// <summary>
        ///     ������ �� �����
        /// </summary>
        all =
            audio | docs | friends | link | messages | notes | notify | offers | pages | photos | questions | video |
            wall
    }
}